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
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.answer4 = answer4;
        if (correctAnswer != answer1 && correctAnswer != answer2 && correctAnswer != answer3 && correctAnswer != answer4) throw new Exception("no correct correctAnswer");
        this.correctAnswer = correctAnswer;
    }
    
    public List<string> ReturnOptions()
    {
        List<string> options =
        [
            answer1,
            answer2,
            answer3,
            answer4
        ];
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