using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    // Arrays for building names
    public static string[] firstNames = {"Colin", "Logan", "Morgan", "Edward", "Leon", "Alan",
        "Cait", "Caspian", "Elora", "Jill", "Carl", "Rick", "Negan", "Carol", "Tyreese", "Michonne",
        "Clementine", "Kelly", "Luke", "Alex", "Glenn", "Megan", "Jerome", "Richard", "Zachary", "Kyle",
        "Wren", "Erica", "Andrew", "Isyss"};

    // Integer for name count
    int nameCount = 15;

    // List Declaration
    List<string> nameList = new List<string> { };

    // HashSet Declarations
    HashSet<string> seen = new HashSet<string>();
    HashSet<string> duplicates = new HashSet<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create list of random names
        for (int i = 0; i < nameCount; i++)
        {
            string name = firstNames[Random.Range(0, firstNames.Length)];
            nameList.Add(name);
        };

        Debug.Log("Created the name array: " + string.Join(", ", nameList));

        // Find duplicate names in list with HashSets
        foreach (string name in nameList)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

        // Report duplicates
        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " + string.Join(", ", duplicates));
        } else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}
