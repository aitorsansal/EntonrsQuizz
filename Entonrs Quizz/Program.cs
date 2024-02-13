// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Entonrs_Quizz;
using System.Media;

class Program
{
    //Main to create the menu and all the actions
    static readonly List<Topic> topics = new();
    static SoundPlayer? sound;
    private static int selectedTopic;
    private static readonly List<Question?> toDoQuestions = new();
    private static Question? questionToDo;
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
        Console.WriteLine($"\n{text}\n");
        Console.ReadKey();
    }

    static void ShowQuestion()
    {
        if (toDoQuestions.Count <= 0)
        {
            MsgNextScreen("Has terminado todas las preguntas de este tópico. \n" +
                          "Pulsa cualquier tecla para continuar.");
            return;
        }
        Random r = new();
        questionToDo = toDoQuestions[r.Next(toDoQuestions.Count)];
        toDoQuestions.Remove(questionToDo);
        bool withSound = questionToDo?.ReturnSoundName() != null;
        Console.WriteLine();
        if(withSound) Console.WriteLine("Sube el volumen.\n");
        Console.WriteLine(questionToDo?.ReturnQuestion());
        int questNum = 1;
        foreach (var option in questionToDo?.ReturnOptions()!)
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
        bool correct = false;
        string? playerAnswer = Console.ReadLine();
        if (int.TryParse(playerAnswer, out int intResponse))
        {
            int i = 0;
            var answers = questionToDo.ReturnOptions();
            while (questionToDo.ReturnCorrectAnswer() != answers[i] && i <= answers.Count) { i++; }

            if (i <= answers.Count) correct = ++i == intResponse;
        }
        else correct = questionToDo.ReturnCorrectAnswer() == playerAnswer;
        Console.WriteLine(correct
            ? "¡Felicidades! ¡¡Lo has adivinado!!"
            : "Mala suerte. Esa no era la respuesta correcta");
        MsgNextScreen("Pulsa cualquier tecla para continuar.");
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
        var question1 = new Question("¿Cuál de los siguientes Pokémon no puede evolucionar?", 
            "Zorua", "Cosmog", "Rotom", "Bulbasur", "Rotom");
        var question2 = new Question("¿Cuál es el nombre del profesor en la región de Kanto?",
            "Oak", "Sebal", "Kukui", "Turo", "Oak");
        var question3 = new Question("¿En qué juego de Pokémon aparece la campeona Cintia por primera vez?",
            "Rojo/Azul", "Sol/Luna", "Diamante/Perla", "Blanco/Negro", "Diamante/Perla");
        var question4 = new Question("¿Cuál es la preevolución del Pokémon \"Lucario\"?",
            "Pikachu", "Riolu", "Lapras", "Gengar", "Riolu");
        var question5 = new Question("¿En qué generación se añadieron las megaevoluciones?",
            "Quinta", "Septima", "Tercera", "Sexta", "Sexta");
        List<Question?> questionsPokemon =
        [
            question1,
            question2,
            question3,
            question4,
            question5
        ];
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
        var question4 = new Question("Con quién se casa Kirito en el anime \"Sword Art Online\"?",
            "Silica", "Asuna", "Yuki", "Lisbeth", "Asuna");
        var question5 = new Question("¿Cómo se llama el gato blanco del anime \"Sailor Moon\"?",
            "Luna", "Artemis", "Rei", "Ami", "Artemis");
        List<Question?> questionsAnime =
        [
            question1,
            question2,
            question3,
            question4,
            question5
        ];
        var animeTopic = new Topic("Anime General", questionsAnime);
        topics.Add(animeTopic);
    }

    static void CreateOpeningsTopic()
    {
        var question1 = new Question("¿De qué anime es el siguiente fragmento de opening?", 
            "Attack On Titan", "Pokémon", "Dragon Ball", "Citrus", "Attack On Titan", "AttackOnTitan.wav");
        var question2 = new Question("¿De qué anime es el siguiente fragmento de opening?", 
            "Frieren", "One Piece", "Oshi No Ko", "Violet Evergarden", "Violet Evergarden","VioletEvergarden.wav");
        var question3 = new Question("¿De qué anime es el siguiente fragmento de opening?", 
            "Citrus", "Akira", "SAO", "Tokyo Revengers", "Citrus", "Citrus.wav");
        var question4 = new Question("¿De qué anime es el siguiente fragmento de opening?", 
            "Vivy: Fluorite Eye's Song", "Spy X Family", "Haikyuu", "Evangelion", "Haikyuu","Haikyuu.wav");
        var question5 = new Question("¿De qué anime es el siguiente fragmento de opening?", 
            "Mirai Nikki", "KonoSuba", "Assassination Classroom", "Kimetsu No Yaiba", "Mirai Nikki","MiraiNikki.wav");
        List<Question?> questionsOpenings =
        [
            question1,
            question2,
            question3,
            question4,
            question5
        ];
        var openingsTopic = new Topic("Openings Anime", questionsOpenings);
        topics.Add(openingsTopic);
    }
    //Manu

    static void CreateManuTopics()
    {
        DragonBallTopics();
        FutbolTopics();
        CulturaGeneralTopics();
    }
    /// <summary>
    /// Creació DragonBallTopic
    /// </summary>
    static void DragonBallTopics()
    {
        Question primera = new Question("¿Quién mata a Freezer?", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        Question segunda = new Question("¿Quién mata a Cell?", "Goku", "Vegeta", "Krillin", "Gohan", "Gohan");
        Question tercera = new Question("¿Quién mata a Majin Buu?", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        Question quarta = new Question("¿Cómo se llama el dios de la destrucción?", "Yamcha", "Bills", "Sayaman", "Nappa", "Bills");
        Question quinta = new Question("¿Quién muere contra Raditz?", "Goku", "Vegeta", "Krillin", "Gohan", "Goku");
        List<Question> preguntasDragonBall =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic DragonBall = new Topic("Dragon Ball", preguntasDragonBall);
        topics.Add(DragonBall);
    }
    /// <summary>
    /// Creació topic futbol
    /// </summary>
    static void FutbolTopics()
    {
        Question primera = new Question("¿Cuándo empezó LaLiga?", "20-04-1930", "10-02-1929", "20-02-1920", "01-03-1940", "10-02-1929");
        Question segunda = new Question("¿Quién es el jugador que ha logrado el trofeo Pichichi en más ocasiones?", "Leo Messi", "Cristiano Ronaldo", "Iniesta", "Xavi", "Leo Messi");
        Question tercera = new Question("¿Quién es el entrenador que ha dirigido durante más temporadas al Atlético de Madrid?", "Mourinho", "Cholo Simeone", "Luis Aragonés", "Pep Guardiola", "Luis Aragonés");
        Question quarta = new Question("¿Cuántas temporadas de Liga se han disputado hasta el día de hoy?", "98", "70", "100", "91", "91");
        Question quinta = new Question("¿Quién ha sido el último Pichichi de LaLiga?", "Bencema", "Leo Messi", "Iniesta", "Levandowski", "Bencema");
        List<Question> preguntasFutbol =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic futbol = new Topic("Futbol", preguntasFutbol);
        topics.Add(futbol);
    }
    /// <summary>
    /// Creacio CulturaGeneralTopic
    /// </summary>
    static void CulturaGeneralTopics()
    {
        Question primera = new Question("¿Cuál es el río más largo del mundo?", "Amazonas", "Duero", "Tajo", "Oñar", "Amazonas");
        Question segunda = new Question("¿Dónde está Transilvania?", "España", "Brasil", "Irlanda", "Rumania", "Rumania");
        Question tercera = new Question("¿Cuántos años duró la Primera Guerra Mundial?", "4", "2", "6", "5", "4");
        Question quarta = new Question("¿Qué año llegó Cristóbal Colón a América?", "1942", "1956", "1926", "1938", "1942");
        Question quinta = new Question("¿Cuántos huesos tiene el cuerpo humano?", "70", "195", "206", "208", "206");
        List<Question> preguntasCulturaGeneral =
            [
                primera,
                segunda,
                tercera,
                quarta,
                quinta
            ];
        Topic culturaGeneral = new Topic("Cultura General", preguntasCulturaGeneral);
        topics.Add(culturaGeneral);
    }
    
}