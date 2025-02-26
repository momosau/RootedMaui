using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp3
{
    public partial class Chatbot : ContentPage
    {

        private const string GeminiApiKey = "AIzaSyBkQcWqNr7uh8bnf57t6HkwfgW1IIr0DPw";
        private const string GeminiApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=" + GeminiApiKey;

        private HttpClient _httpClient = new HttpClient();
        private ObservableCollection<Message> _chatMessages = new ObservableCollection<Message>();

        public Chatbot()
        {
            InitializeComponent();
            ChatList.ItemsSource = _chatMessages;
        }

        private async void OnSendButtonClicked(object sender, EventArgs e)
        {
            string userMessage1 = MessageEntry.Text;
            string userMessage = "أنا مساعد ذكاء اصطناعي متخصص في مجال الزراعة. " +
                                 "يمكنك طرح أي أسئلة تتعلق بالزراعة، وسأقدم لك الإجابات المناسبة لمساعدتك. " +
"إذا كان سؤالك خارج نطاق الزراعة، فسأجيبك بعبارة: " +
"أنا ذكاء اصطناعي مخصص لمساعدتك في ما يخص الزراعة فقط. " +
"أريد الإجابة عن جميع الأسئلة التي تتعلق بالزراعة ومساعدة المزارعين فقط. " +
"ملاحظة: يُرجى القيام بما هو مطلوب منك فقط. " +
"هذا هو نص الرسالة: " + MessageEntry.Text;

            if (string.IsNullOrWhiteSpace(userMessage1))
                return;

            _chatMessages.Add(new Message { Text = userMessage1, IsUserMessage = true });
            MessageEntry.Text = string.Empty;

            string response = await SendMessageToGemini(userMessage);
            _chatMessages.Add(new Message { Text = response, IsUserMessage = false });
        }

        private async Task<string> SendMessageToGemini(string message)
        {
            try
            {
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new
                                {
                                    text = message
                                }
                            }
                        }
                    }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(GeminiApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseJson);
                    return responseObject.candidates[0].content.parts[0].text;
                }
                else
                {
                    return "حدث خطأ أثناء الاتصال بالذكاء الاصطناعي.";
                }
            }
            catch (Exception ex)
            {
                return "حدث خطأ: " + ex.Message;
            }
        }
    }

    public class Message
    {
        public string Text { get; set; }
        public bool IsUserMessage { get; set; }
    }

    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UserMessageTemplate { get; set; }
        public DataTemplate ChatMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Message message)
            {
                return message.IsUserMessage ? UserMessageTemplate : ChatMessageTemplate;
            }
            return null;
        }
    }
}
