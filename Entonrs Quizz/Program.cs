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
        Topic topic1 = new Topic("a", "b", "c", "c1", "c2", "c3", "c");
        Topic topic2 = new Topic("abcsa", "b", "c", "c1", "c2", "c3", "c");
        topics.Add(topic1);
        topics.Add(topic2);
    }
    //Manu
}