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

    // Variable for random player count
    float randPlayerCount;

    // Queue Declaration
    Queue<string> loginQueue = new Queue<string>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generate random amount of players
        randPlayerCount = Random.Range(4, 6 + 1);

        // Start Add Player Coroutine
        StartCoroutine(AddPlayer());
    }

    // Grabs a random first name and a random last initial and combines them into one string
    public string GetRandomPlayerName()
    {
        string playerName = firstNames[Random.Range(0, firstNames.Length)] + " " + lastInitials[Random.Range(0, lastInitials.Length)];
        return playerName;
    }

    // Add Player Coroutine - Logs when players are attempting to login 
    public IEnumerator AddPlayer()
    {
        // Build the Queue with random names and a random amount of players
        for (int i = 0; i < randPlayerCount; i++)
        {
            string playerName = GetRandomPlayerName();
            loginQueue.Enqueue(playerName);
            Debug.Log(playerName + " is trying to login and added to the login queue.");
            yield return new WaitForSeconds(3);
        };

        // Create List with the Queue
        List<string> playerList = loginQueue.ToList();
        Debug.Log("Initial login queue created. There are " + randPlayerCount + " players in the queue: " + string.Join(", ", playerList));
        yield return new WaitForSeconds(3);

        // Start Login Player Coroutine
        StartCoroutine(LoginPlayer());
    }

    // Login Player Coroutine - Logs when players have logged in
    public IEnumerator LoginPlayer()
    {
        int waitingPlayers = loginQueue.Count;
        for (int i = waitingPlayers; i > 0; i--)
        {
            string loggedInPLayer = loginQueue.Dequeue();
            Debug.Log(loggedInPLayer + " is now inside the game.");
            yield return new WaitForSeconds(3);
        }

        // Log when for loop is finished.
        Debug.Log("Login server is idle. No players are waiting.");
    }
}
