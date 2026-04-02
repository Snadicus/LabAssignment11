using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task3 : MonoBehaviour
{
    // Variables
    string[] deck = new string[16]; // Holds the deck of cards
    Stack<string> shuffledDeck = new Stack<string>(); // holds shuffled deck 
    List<string> hand = new List<string>(); // holds current hand

    void Start()
    {
        // Instantiating deck of cards
        deck = new string[16]{
            "K♥", "Q♥", "J♥", "A♥",
            "K♦", "Q♦", "J♦", "A♦",
            "K♣", "Q♣", "J♣", "A♣",
            "K♠", "Q♠", "J♠", "A♠"
        };

        ShuffleDeck();
    }

    // Shuffles the deck
    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Length; i++) 
        { 
            int chosenCard = Random.Range(0, deck.Length); // Randomly picks a card
            // Checks if random card is already in stack.
            // if it is add card to the stack
            // else pick up another random card
            if (shuffledDeck.Count > 0)
            {
                while (shuffledDeck.Contains(deck[chosenCard]))
                {
                    chosenCard = Random.Range(0, deck.Length);
                }
            }
            shuffledDeck.Push(deck[chosenCard]);
        }

        MakeHand(); // Makes hand
        StartCoroutine(PlayGame()); // Starts the game
    }

    // Function that runs once to make players initial hand
    void MakeHand()
    {
        // while hand has less than 4 remove first card from stack and add it to the hand
        while (hand.Count < 4)
        {
            hand.Add(shuffledDeck.Pop());
        }
        // prints initial hand
        Debug.Log($"I made the initial deck and draw. My hand is: {GetHand(hand)}");
    }

    // Main game loop
    IEnumerator PlayGame()
    {
        string discardStatment = ""; // variable to print what was discarded and added
        // Runs when cards are in the deck
        while (shuffledDeck.Count > 0)
        {
            // Gets a random card to discard
            int discardedInt = Random.Range(0, hand.Count);
            string discardedCard = hand[discardedInt];
            // Gets the card on the top of the stack
            string newCard = shuffledDeck.Pop();
            // Changes discard statement based on previous two variables
            discardStatment = $"I discarded {discardedCard} and drew {newCard}.";
            // Removes and adds cards
            hand.RemoveAt(discardedInt);
            hand.Add(newCard);
            // Checks if there are 3 or more cards of the same suit
            if (CheckDeck())
            {
                // prints game is won and stop coroutine
                Debug.Log($"{discardStatment} {GetHand(hand)} The game is WON.");
                StopAllCoroutines();
            }
            else 
            { 
                Debug.Log($"{discardStatment} {GetHand(hand)} This is not a winning hand. I will attempt to play another round."); 
            }
            
            yield return null;
        }
        // Oncedeck is empty lose game
        LostGame();
    }

    // Function that runs once deck is empty
    void LostGame()
    {
        Debug.Log("The deck is empty.\n Game Over.");
    }

    // Funtion that checks if there are 3 or more cards with the same suite
    bool CheckDeck()
    {
        int similarAmount = 1; // variable to check and add amount of similar cards
        char suite = hand[0].Last(); // Sets current suit based on first card in hand
        // Loops through hand not including first card
        for (int i = 1; i < hand.Count; i++)
        {
            // If card suits match, add 1 to similar amount
            if (hand[i].Last() == suite)
            {
                similarAmount++;
            }
            // return true if 3 cards have the same suit
            if (similarAmount == 3)
            {
                return true;
            }
        }
        // reset based on the second card in hands deck
        similarAmount = 1;
        suite = hand[1].Last();
        // same as before but based on the 2nd card
        for (int i = 2; i < hand.Count; i++)
        {
            if (hand[i].Last() == suite)
            {
                similarAmount++;
            }
            if (similarAmount == 3)
            {
                return true;
            }
        }
        return false;
    }

    // Returns a string showing full hand
    string GetHand(List<string> hand)
    {
        // start of string to return
        string currentHand = "My current hand is: ";
        foreach (string card in hand)
        {
            // Adds card name
            if (card == hand[3])
            {
                currentHand += $"{card}.";
            }
            else
            {
                currentHand += $"{card}, ";
            }
        }
        return currentHand;
    }
}
