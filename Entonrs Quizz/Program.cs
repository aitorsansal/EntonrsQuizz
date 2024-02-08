// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Entonrs_Quizz;

internal class Program
{
    //Main to create the menu and all the actions
    static List<Topic> topics = new();
    public static void Main(string[] args)
    {
        CreateMenu();
    }

    static void CreateMenu()
    {
        for (int i = 0; i < topics.Count; i++)
        {
            Console.WriteLine($"Topic {i+1}: {topics[i].ReturnTitle()}");
        }
    }
    //Aitor
    static void CreateAitorTopics()
    {
        
    }
    //Manu

    static void CreateManuTopics()
    {
        DragonBallTopics();
    }
    static void DragonBallTopics()
    {
        Question primera = new Question("Quien mata a Freezer", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        Question segunda = new Question("Quien mata a Cell", "Goku", "Vegeta", "Krillin", "Gohan", "Gohan");
        Question tercera = new Question("Quien mata a Magin Buu", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        Question quarta = new Question("Quien no es hijo de goku", "Trunks", "Goten", "Bra", "Gohan", "Trunks");
        Question quinta = new Question("Quien muere contra radditz", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        List<Question> PreguntasDragonBall =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic DragonBall = new Topic("Dragon Ball", PreguntasDragonBall);
        topics.Add(DragonBall);
    }
}