// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Entonrs_Quizz;

internal class Program
{
    //Main to create the menu and all the actions
    static List<Topic> topics = new();
    public static void Main(string[] args)
    {
        CreateAitorTopics();
        CreateManuTopics();
        CreateMenu();
    }

    static void CreateMenu()
    {
        Console.Clear();
        for (int i = 0; i < topics.Count; i++)
        {
            Console.WriteLine($"Topic {i+1}: {topics[i].ReturnTitle()}");
        }
    }
    //Aitor
    static void CreateAitorTopics()
    {
        CreatePokemonTopic();
        CreateAnimeTopic();
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
        List<Question> questionsPokemon =
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
        var question4 = new Question("Con quien se casa Kirito en el anime \"Sword Art Online\"?",
            "Silica", "Asuna", "Yuki", "Lisbeth", "Asuna");
        var question5 = new Question("¿Como se llama el gato blanco del anime \"Sailor Moon\"?",
            "Luna", "Artemis", "Rei", "Ami", "Artemis");
        List<Question> questionsAnime =
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

    //Manu

    static void CreateManuTopics()
    {
        
    }
}