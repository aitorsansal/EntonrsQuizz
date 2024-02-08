// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Entonrs_Quizz;
using System.Media;

class Program
{
    //Main to create the menu and all the actions
    static List<Topic> topics = new();
    static SoundPlayer sound;
    private static int selectedTopic;
    private static List<Question> toDoQuestions = new();
    private static Question questionToDo;
    public static void Main(string[] args)
    {
        CreateAitorTopics();
        CreateManuTopics();
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            CreateMenu();
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.NumPad1: case ConsoleKey.D1:
                    selectedTopic = 0;
                    break;
                case ConsoleKey.NumPad2: case ConsoleKey.D2:
                    selectedTopic = 1;
                    break;
                case ConsoleKey.NumPad3: case ConsoleKey.D3:
                    selectedTopic = 2;
                    break;
                case ConsoleKey.NumPad4: case ConsoleKey.D4:
                    selectedTopic = 3;
                    break;
                case ConsoleKey.NumPad5: case ConsoleKey.D5:
                    selectedTopic = 4;
                    break;
                case ConsoleKey.NumPad6: case ConsoleKey.D6:
                    selectedTopic = 5;
                    break;
            }

            foreach (var question in topics[selectedTopic].ReturnQuestions())
            {
                toDoQuestions.Add(question);
            }
            ShowQuestion();
        } while (key.Key is not ConsoleKey.D0 and not ConsoleKey.NumPad0);
    }

    static void CreateMenu()
    {
        Console.WriteLine("Elige el tópico de las preguntas:");
        for (int i = 0; i < topics.Count; i++)
        {
            Console.WriteLine($"Topic {i+1}: {topics[i].ReturnTitle()}");
        }

        Console.WriteLine("\n\n(Presione \"0\" para salir)");
    }
    static void MsgNextScreen(string text)
    {
        Console.WriteLine(text);
        Console.ReadKey();
    }

    static void ShowQuestion()
    {
        if (toDoQuestions.Count <= 0)
        {
            MsgNextScreen("a");
            return;
        }
        Random r = new();
        questionToDo = toDoQuestions[r.Next(toDoQuestions.Count)];
        toDoQuestions.Remove(questionToDo);
        bool withSound = questionToDo.ReturnSoundName() != null;
        if(withSound) Console.WriteLine("Sube el volumen.");
        Console.WriteLine(questionToDo.ReturnQuestion());
        int questNum = 1;
        foreach (var option in questionToDo.ReturnOptions())
        {
            Console.WriteLine($"{questNum++}) {option}");
        }

        if (withSound)
        {
            sound = new SoundPlayer(questionToDo.ReturnSoundName());
            sound.PlaySync();
        }
        CheckForAnswer();
    }

    static void CheckForAnswer()
    {
        string playerAnswer = Console.ReadLine();
        Console.WriteLine(questionToDo.ReturnCorrectAnswer() == playerAnswer
            ? "Congratulations!!! You got it right!!!"
            : "Too bad. That wasn't the right answer.");
        MsgNextScreen("Press a key to continue");
        ShowQuestion();
    }
    //Aitor
    static void CreateAitorTopics()
    {
        CreatePokemonTopic();
        CreateAnimeTopic();
        CreateOpeningsTopic();
    }

    static void CreatePokemonTopic()
    {
        var question1 = new Question("¿Cual de los siguientes Pokémon no puede evolucionar?", 
            "Zorua", "Cosmog", "Rotom", "Bulbasur", "Rotom");
        var question2 = new Question("¿Cual es el nombre del profesor en la región de Kanto?",
            "Oak", "Sebal", "Kukui", "Turo", "Oak");
        var question3 = new Question("¿En que juego de Pokémon aparece la campeona Cintia por primera vez?",
            "Rojo/Azul", "Sol/Luna", "Diamante/Perla", "Blanco/Negro", "Diamante/Perla");
        var question4 = new Question("¿Cual es la preevolución del Pokémon \"Lucario\"?",
            "Pikachu", "Riolu", "Lapras", "Gengar", "Riolu");
        var question5 = new Question("¿En que generación se añadieron las megaevoluciones?",
            "Quinta", "Septima", "Tercera", "Sexta", "Sexta");
        List<Question> questionsPokemon = new List<Question>
        { 
            question1,
            question2,
            question3,
            question4,
            question5
        };
        var pokemonTopic = new Topic("Pokémon", questionsPokemon);
        topics.Add(pokemonTopic);
    }
    
    static void CreateAnimeTopic()
    {
        var question1 = new Question("¿En \"Death Note\", ¿cuál es el nombre del detective que persigue al protagonista Light Yagami?", 
            "L", "N", "A", "M", "L");
        var question2 = new Question("¿Cuál es el nombre de la organización secreta que busca recolectar todas las Esferas del Dragón en \"Dragon Ball Z\"?", 
            "Namekianos", "Clan Frieza", "Red Ribbon", "Guerreros Z", "Red Ribbon");
        var question3 = new Question("En \"Attack on Titan\", ¿cuál es el nombre del personaje principal que jura vengarse de los Titanes por destruir su hogar y su familia?",
            "Eren Nigger", "Mikasa Ackerman", "Eren Jaeger", "Sasha Blouse", "Eren Jaeger");
        var question4 = new Question("Con quien se casa Kirito en el anime \"Sword Art Online\"?",
            "Silica", "Asuna", "Yuki", "Lisbeth", "Asuna");
        var question5 = new Question("¿Como se llama el gato blanco del anime \"Sailor Moon\"?",
            "Luna", "Artemis", "Rei", "Ami", "Artemis");
        List<Question> questionsAnime = new()
        {
            question1,
            question2,
            question3,
            question4,
            question5
        };
        var animeTopic = new Topic("Anime General", questionsAnime);
        topics.Add(animeTopic);
    }

    static void CreateOpeningsTopic()
    {
        var question1 = new Question("¿De que anime es el siguiente fragmento de opening?", 
            "Attack On Titan", "Pokémon", "Dragon Ball", "Citrus", "Attack On Titan", "AttackOnTitan.wav");
        var question2 = new Question("¿De que anime es el siguiente fragmento de opening?", 
            "Frieren", "One Piece", "Oshi No Ko", "Violet Evergarden", "Violet Evergarden","VioletEvergarden.wav");
        var question3 = new Question("¿De que anime es el siguiente fragmento de opening?", 
            "Citrus", "Akira", "SAO", "Tokyo Revengers", "Citrus", "Citrus.wav");
        var question4 = new Question("¿De que anime es el siguiente fragmento de opening?", 
            "Vivy: Fluorite Eye's Song", "Spy X Family", "Haikyuu", "Evangelion", "Haikyuu","Haikyuu.wav");
        var question5 = new Question("¿De que anime es el siguiente fragmento de opening?", 
            "Mirai Nikki", "KonoSuba", "Assassination Classroom", "Kimetsu No Yaiba", "Mirai Nikki","MiraiNikki.wav");
        List<Question> questionsOpenings = new()
        {
            question1,
            question2,
            question3,
            question4,
            question5
        };
        var openingsTopic = new Topic("Openings Anime", questionsOpenings);
        topics.Add(openingsTopic);
    }
    //Manu

    static void CreateManuTopics()
    {
        
    }
    
}