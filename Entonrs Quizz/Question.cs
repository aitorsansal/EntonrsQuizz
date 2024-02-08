using System.Formats.Asn1;

namespace Entonrs_Quizz;

public class Question
{
    private string question;
    private string answer1;
    private string answer2;
    private string answer3;
    private string answer4;
    private string correctAnswer;
    private string? soundName;

    public Question( string question, string answer1, string answer2, string answer3, string answer4,
        string correctAnswer):this(question,answer1, answer2, answer3, answer4, correctAnswer,null)
    { }

    public Question(string question, string answer1, string answer2, string answer3, string answer4,
        string correctAnswer, string? soundName)
    {
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.answer4 = answer4;
        if (correctAnswer != answer1 && correctAnswer != answer2 && correctAnswer != answer3 && correctAnswer != answer4) throw new Exception("no correct correctAnswer");
        this.correctAnswer = correctAnswer;
        this.soundName = soundName;
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

    public string? ReturnSoundName()
    {
        return soundName;
    }
}