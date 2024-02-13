namespace Entonrs_Quizz;

public class Topic
{
    private string title;
    private List<Question?> questions = new();

    public Topic(string title, List<Question?> questions)
    {
        this.title = title;
        this.questions = questions;
    }

    public List<Question?> ReturnQuestions()
    {
        return questions;
    }
    public string ReturnTitle()
    {
        return title;
    }
}