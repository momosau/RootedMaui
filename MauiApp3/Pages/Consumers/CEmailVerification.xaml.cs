using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MauiApp3.Pages.Consumers;

public partial class CEmailVerification : ContentPage
{
    private string _verificationCode;
    private readonly HttpClient _httpClient = new HttpClient();

    private const string SmtpHost = "smtp.gmail.com";
    private const int SmtpPort = 587;
    private const string SmtpUsername = "reachout.rooted@gmail.com";
    private const string SmtpPassword = "xixw wprf fqdo tagy";
    private const string ApiUrl = "http://localhost:7168/api/Consumers";
    private Consumer _consumer;

    public CEmailVerification(Consumer consumer)
	{
        InitializeComponent();
        _consumer = consumer;
        emailLabel.Text = $"������: {_consumer.Email}";
        GenerateAndSendVerificationCode();
    }


        private void GenerateAndSendVerificationCode()
        {
            _verificationCode = RandomNumberGenerator.GetInt32(1000, 9999).ToString();
            Debug.WriteLine($"��� ������: {_verificationCode}");
            Task.Run(() => SendVerificationEmail(_consumer.Email, _verificationCode));
        }

        private async Task SendVerificationEmail(string email, string code)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Rooted", SmtpUsername));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "��� ������ - ����� Rooted";
                var imageUrl = "https://i.ibb.co/hRzTwb7j/rooted-logo.png";
                var bodyBuilder = new BodyBuilder();

                // ����� ���� ���� ������ �������
                var imageId = MimeUtils.GenerateMessageId();

                // HTML �� ����� ������
                bodyBuilder.HtmlBody = $@"
                <!DOCTYPE html>
                <html dir='rtl'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>��� ������</title>
                    <style>
                        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 0; padding: 0; background-color: #f5f5f5; }}
                        .container {{ max-width: 600px; margin: 20px auto; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 0 10px rgba(0,0,0,0.1); }}
                        .header {{ background-color: #E7E9E4; padding: 20px; text-align: center; }}
                        .content {{ padding: 30px; }}
                        .logo {{ height: 60px; }}
                        .code {{ background: #f0f7f0; padding: 15px; text-align: center; margin: 20px 0; border-radius: 5px; font-size: 24px; font-weight: bold; color: #0E3230; letter-spacing: 3px; }}
                        .footer {{ background-color: #E7E9E4; padding: 15px; text-align: center; font-size: 12px; color: #0E3230; border-top: 1px solid #eee; }}
                        .button {{ display: inline-block; background-color: #3E6F41; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; margin: 10px 0; }}
                        @media only screen and (max-width: 600px) {{
                            .content {{ padding: 15px; }}
                            .code {{ font-size: 20px; }}
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <img class='logo' src='{imageUrl}' alt='Rooted Logo'>
                        </div>
                        <div class='content'>
                            <h2 style='color: #0E3230;'>������ �� �� ����� Rooted</h2>
                            <p>����� ������� ����. ���� ������� ��� ������ ������ ������ ����� �������:</p>
                            
                            <div class='code'>{code}</div>
                            
                            <p>��� ����� ���� ���� 10 ����� ���.</p>
                            
                         
                            
                            <p style='font-size: 14px; color: #0E3230; margin-top: 30px;'>
                                ��� �� ���� ��� ����ҡ ���� ����� ��� ������� �� ������� �� ���� �����.
                            </p>
                        </div>
                        <div class='footer'>
                            � {DateTime.Now.Year} Rooted. ���� ������ ������.<br>
                            support@rooted.com | +966 12 345 6789
                        </div>
                    </div>
                </body>
                </html>";

                // ���� ��� ������� ����� �� ������ HTML
                bodyBuilder.TextBody = $"��� ������ ����� �� ��: {code}\n\n" +
                                      "������ ����� ��� ����� �� ������� ������ ����� �������.\n\n" +
                                      "��� ����� ���� ���� 10 ����� ���.\n\n" +
                                      "��� �� ���� ��� ����ҡ ���� ����� ��� �������.";

                // ����� ���� ������ �����
                var assembly = GetType().GetTypeInfo().Assembly;
                using var stream = assembly.GetManifestResourceStream("MauiApp3.Resources.Images.rooted_logo.png");
                if (stream != null)
                {
                    var image = bodyBuilder.LinkedResources.Add("logo.png", stream);
                    image.ContentId = imageId;
                }

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(SmtpHost, SmtpPort, false);
                    await client.AuthenticateAsync(SmtpUsername, SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("�� �������", "�� ����� ��� ������ ��� ����� ����������", "�����");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"��� ����� ������: {ex}");
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("���", "��� �� ����� ��� �����ޡ ���� �������� ������", "�����");
                });
            }
        }

        private void MoveText(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry currentEntry && !string.IsNullOrEmpty(e.NewTextValue))
            {
                if (currentEntry == pin1) pin2.Focus();
                else if (currentEntry == pin2) pin3.Focus();
                else if (currentEntry == pin3) pin4.Focus();
            }
        }

        private async void VerifyCode(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pin1.Text) || string.IsNullOrEmpty(pin2.Text) ||
                    string.IsNullOrEmpty(pin3.Text) || string.IsNullOrEmpty(pin4.Text))
                {
                    await DisplayAlert("���", "������ ����� ��� ������ �������", "�����");
                    return;
                }

                string enteredCode = $"{pin1.Text}{pin2.Text}{pin3.Text}{pin4.Text}";

                if (enteredCode != _verificationCode)
                {
                    await DisplayAlert("���", "��� ������ ��� ����", "�����");
                    return;
                }

                loadingIndicator.IsVisible = true;
                verifyButton.IsEnabled = false;
                resendButton.IsEnabled = false;

                bool isSuccess = await UploadData(_consumer);

                if (isSuccess)
                {
                    await DisplayAlert("����", "�� ����� ������� �����", "�����");
                    await Navigation.PushAsync(new ConsumerHomePage(_consumer));
                }
                else
                {
                    await DisplayAlert("���", "��� �� ����� �������", "�����");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("���", $"��� ��� ��� �����: {ex.Message}", "�����");
                Debug.WriteLine($"Error: {ex}");
            }
            finally
            {
                loadingIndicator.IsVisible = false;
                verifyButton.IsEnabled = true;
                resendButton.IsEnabled = true;
            }
        }

        private async Task<bool> UploadData(Consumer consumer)
        {
            try
            {
                var json = JsonConvert.SerializeObject(consumer);
                Debug.WriteLine($"JSON to API: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(ApiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"API Error: {errorContent}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Upload Error: {ex}");
                return false;
            }
        }

        private async void OnResendClicked(object sender, EventArgs e)
        {
            try
            {
                resendButton.IsEnabled = false;
                loadingIndicator.IsVisible = true;
                GenerateAndSendVerificationCode();
                await DisplayAlert("��", "�� ����� ��� ���� ���� ��� ����� ����������", "�����");
            }
            catch (Exception ex)
            {
                await DisplayAlert("���", $"��� �� ����� �������: {ex.Message}", "�����");
            }
            finally
            {
                loadingIndicator.IsVisible = false;
                resendButton.IsEnabled = true;
            }
        }
    }
