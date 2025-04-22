using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace MauiApp3.Pages.Consumers;

public partial class CForgotPassEmail : ContentPage
{
    private const string apiUrl = "http://localhost:7168/api/Consumer/ResetPassword";
    private readonly HttpClient _httpClient = new HttpClient();
    public CForgotPassEmail()
	{
		InitializeComponent();
	}


    private async void CheckEmailClicked(object sender, EventArgs e)
    {
        var emailRequest = new EmailCheckRequest
        {
            Email = EmailEntry.Text
        };

        var response = await _httpClient.PostAsJsonAsync(apiUrl, emailRequest);
        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("��", "������ ���������� ���� ����� ��������.", "�����");
            // ���� ���� ��� ������� ����� ����� ��� ������ �� ����� ���� ������
            await Navigation.PushAsync(new CVerificationCodePage(EmailEntry.Text));

        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            await DisplayAlert("���", errorMessage, "�����");
        }
    }
}

public class EmailCheckRequest
{
    public string Email { get; set; }
}

