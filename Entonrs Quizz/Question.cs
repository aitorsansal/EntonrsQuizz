namespace Entonrs_Quizz;

public class Question
{
    private string question;
    private string answer1;
    private string answer2;
    private string answer3;
    private string answer4;
    private string correctAnswer;

    public Question( string question, string answer1, string answer2, string answer3, string answer4,
        string correctAnswer)
    {
        if (correctAnswer != answer1 && correctAnswer != answer2 && correctAnswer != answer3 && correctAnswer != answer4) throw new Exception("no correct correctAnswer");
        this.correctAnswer = correctAnswer;
    }
    
    public List<string> ReturnOptions()
    {
        List<string> options = new();
        options.Add(answer1);
        options.Add(answer2);
        options.Add(answer3);
        options.Add(answer4);
        return options;
    }
    
    public string ReturnCorrectAnswer()
    {
        return correctAnswer;
    }
    
    public string ReturnQuestion()
    {
        return question;
    }
}