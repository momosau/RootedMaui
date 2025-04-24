using System.Collections.ObjectModel;
using AdminApp.Services;
using SharedLibraryy.Models;

namespace AdminApp.ViewModel;

public class QuestionViewModel : BaseViewModel
{
    private readonly QuestionService _service;
    public ObservableCollection<Question> Questions { get; set; } = new();

    public QuestionViewModel()
    {
        _service = new QuestionService();
        LoadQuestions();
    }

    private async void LoadQuestions()
    {
        try
        {
            var list = await _service.GetQuestions();

            Questions.Clear();
            foreach (var q in list)
            {
              
                Questions.Add(q);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("فشل تحميل الأسئلة: " + ex.Message);
        }
    }
}
