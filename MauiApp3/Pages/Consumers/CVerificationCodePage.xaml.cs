using MimeKit.Utils;
using MimeKit;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using Microsoft.Maui.ApplicationModel.Communication;

namespace MauiApp3.Pages.Consumers;

public partial class CVerificationCodePage : ContentPage
{
    private string _email;
    private string _verificationCode;
    private const string SmtpHost = "smtp.gmail.com";
    private const int SmtpPort = 587;
    private const string SmtpUsername = "reachout.rooted@gmail.com";
    private const string SmtpPassword = "xixw wprf fqdo tagy";
    public CVerificationCodePage(string email)
    {
        InitializeComponent();
        _email = email;
        emailLabel.Text = $"البريد: {_email}";
        GenerateAndSendVerificationCode();

    }


    private void GenerateAndSendVerificationCode()
    {
        _verificationCode = RandomNumberGenerator.GetInt32(1000, 9999).ToString();
        Debug.WriteLine($"رمز التحقق: {_verificationCode}");
        Task.Run(() => SendVerificationEmail(_email, _verificationCode));
    }

    private async Task SendVerificationEmail(string email, string code)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rooted", SmtpUsername));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "رمز إعادة تعيين كلمة المرور - تطبيق Rooted";

            var imageUrl = "https://i.ibb.co/ynCBKT1R/rooted-logo.png";
            var bodyBuilder = new BodyBuilder();
            var imageId = MimeUtils.GenerateMessageId();

            bodyBuilder.HtmlBody = $@"
            <!DOCTYPE html>
            <html dir='rtl'>
            <head>
                <meta charset='UTF-8'>
                <title>إعادة تعيين كلمة المرور</title>
                <style>
                    body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f5f5f5; }}
                    .container {{ max-width: 600px; margin: 20px auto; background: white; border-radius: 10px; box-shadow: 0 0 10px rgba(0,0,0,0.1); }}
                    .header {{ background-color: #E7E9E4; padding: 20px; text-align: center; }}
                    .content {{ padding: 30px; }}
                    .logo {{ height: 60px; }}
                    .code {{ background: #f0f7f0; padding: 15px; text-align: center; border-radius: 5px; font-size: 24px; font-weight: bold; color: #0E3230; letter-spacing: 3px; }}
                    .footer {{ background-color: #E7E9E4; padding: 15px; text-align: center; font-size: 12px; color: #0E3230; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <img class='logo' src='{imageUrl}' alt='Rooted Logo'>
                    </div>
                    <div class='content'>
                        <h2 style='color: #0E3230;'>إعادة تعيين كلمة المرور</h2>
                        <p>لقد استلمنا طلبًا لإعادة تعيين كلمة المرور الخاصة بك.</p>
                        <div class='code'>{code}</div>
                        <p>يرجى إدخال الرمز في التطبيق لإتمام العملية. هذا الرمز صالح لمدة 10 دقائق.</p>
                        <p style='font-size: 14px; color: #0E3230;'>إذا لم تطلب هذا الرمز، يرجى تجاهل هذه الرسالة.</p>
                    </div>
                    <div class='footer'>
                        © {DateTime.Now.Year} Rooted. جميع الحقوق محفوظة.<br>
                        support@rooted.com | +966 12 345 6789
                    </div>
                </div>
            </body>
            </html>";

            bodyBuilder.TextBody = $"رمز إعادة تعيين كلمة المرور هو: {code}\n\n" +
                                   "أدخل هذا الرمز في التطبيق لإعادة تعيين كلمة المرور.\n\n" +
                                   "إذا لم تطلب هذا الرمز، يمكنك تجاهل هذه الرسالة.";

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
                await DisplayAlert("تم الإرسال", "تم إرسال رمز التحقق إلى بريدك الإلكتروني", "موافق");
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"فشل إرسال البريد: {ex}");
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("خطأ", "فشل في إرسال رمز التحقق، يرجى المحاولة لاحقاً", "موافق");
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
        string enteredCode = $"{pin1.Text}{pin2.Text}{pin3.Text}{pin4.Text}";

        if (enteredCode != _verificationCode)
        {
            await DisplayAlert("خطأ", "رمز التحقق غير صحيح", "موافق");
            return;
        }

        await DisplayAlert("تم التحقق", "تم التحقق من الرمز بنجاح، يمكنك الآن تعيين كلمة مرور جديدة", "موافق");

        //التنقل لصفحة تعيين كلمة المرور الجديدة
        await Navigation.PushAsync(new CResetPasswordPage(_email));


    }
}