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
        FutbolTopics();
        CulturaGeneralTopics();
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
    static void FutbolTopics()
    {
        Question primera = new Question("¿Cuándo empezó LaLiga?", "20-04-1930", "10-02-1929", "20-02-1920", "01-03-1940", "10-02-1929");
        Question segunda = new Question("¿Quién es el jugador que ha logrado el trofeo Pichichi en más ocasiones?", "Leo Messi", "Cristiano Ronaldo", "Iniesta", "Xavi", "Leo Messi");
        Question tercera = new Question("¿Quién es el entrenador que ha dirigido durante más temporadas al Atlético de Madrid?", "Mourinho", "Cholo Simeone", "Luis Aragonés", "Pep Guardiola", "Luis Aragonés");
        Question quarta = new Question("¿Cuántas temporadas de Liga se han disputado hasta el día de hoy?", "98", "70", "100", "91", "91");
        Question quinta = new Question("¿Quién ha sido el último Pichichi de LaLiga?", "Bencema", "Leo Messi", "Iniesta", "Levandowski", "Bencema");
        List<Question> PreguntasFutbol =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic Futbol = new Topic("Futbol", PreguntasFutbol);
        topics.Add(Futbol);
    }
    static void CulturaGeneralTopics()
    {
        Question primera = new Question("¿Cuál es el río más largo del mundo?", "Amazonas", "Duero", "Tajo", "Oñar", "Amazonas");
        Question segunda = new Question("¿Dónde está Transilvania?", "España", "Brasil", "Irlanda", "Rumania", "Rumania");
        Question tercera = new Question("¿Cuántos años duró la Primera Guerra Mundial?", "4", "2", "6", "5", "4");
        Question quarta = new Question("¿Qué año llegó Cristóbal Colón a América?", "1942", "1956", "1926", "1938", "1942");
        Question quinta = new Question("¿Cuántos huesos tiene el cuerpo humano?", "70", "195", "206", "208", "206");
        List<Question> PreguntasCulturaGeneral =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic CulturaGeneral = new Topic("Cultura General", PreguntasCulturaGeneral);
        topics.Add(CulturaGeneral);
    }
}