using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    // Arrays for building names
    public static string[] firstNames = {"Colin", "Logan", "Morgan", "Edward", "Leon", "Alan",
        "Cait", "Caspian", "Elora", "Jill", "Carl", "Rick", "Negan", "Carol", "Tyreese", "Michonne", 
        "Clementine", "Kelly", "Luke", "Alex", "Glenn", "Megan", "Jerome", "Richard", "Zachary", "Kyle", 
        "Wren", "Erica", "Andrew", "Isyss"};
    public static string[] lastInitials = {"A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", 
        "I.", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", 
        "W.", "X.", "Y.", "Z."};

    // Queue Declaration
    Queue<string> loginQueue = new Queue<string>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Build the Queue with random names and a random amount of players
        float randPlayerCount = Random.Range(4, 6+1);
        for (int i = 0; i < randPlayerCount; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        };

        // Create List with the Queue
        List<string> playerList = loginQueue.ToList();
        Debug.Log("Initial login queue created. There are " + randPlayerCount + " players in the queue:" + playerList);
    }

    // Grabs a random first name and a random last initial and combines them into one string
    public string GetRandomPlayerName()
    {
        string playerName = firstNames[Random.Range(0, firstNames.Length)] + " " + lastInitials[Random.Range(0, lastInitials.Length)];
        return playerName;
    }

}
