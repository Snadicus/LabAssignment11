using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task3 : MonoBehaviour
{
    string[] deck = new string[16];
    Stack<string> shuffledDeck = new Stack<string>();
    List<string> hand = new List<string>();
    void Start()
    {
        deck = new string[16]{
            "K♥", "Q♥", "J♥", "A♥",
            "K♦", "Q♦", "J♦", "A♦",
            "K♣", "Q♣", "J♣", "A♣",
            "K♠", "Q♠", "J♠", "A♠"
        };

        ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Length; i++) 
        { 
            int chosenCard = Random.Range(0, deck.Length);
            if (shuffledDeck.Count > 0)
            {
                while (shuffledDeck.Contains(deck[chosenCard]))
                {
                    chosenCard = Random.Range(0, deck.Length);
                }
            }
            shuffledDeck.Push(deck[chosenCard]);
        }

        MakeHand();
        StartCoroutine(PlayGame());
    }

    void MakeHand()
    {
        while (hand.Count < 4)
        {
            hand.Add(shuffledDeck.Pop());
        }
        Debug.Log($"I made the initial deck and draw. My hand is: {GetHand(hand)}");
    }

    IEnumerator PlayGame()
    {
        string discardStatment = "";
        string winningHand = "";
        while (shuffledDeck.Count > 0)
        {
            int discardedInt = Random.Range(0, hand.Count);
            string discardedCard = hand[discardedInt];
            string newCard = shuffledDeck.Pop();
            hand.RemoveAt(discardedInt);
            hand.Add(newCard);
            if (CheckDeck())
            {
                WonGame();
                StopAllCoroutines();
            }
            yield return null;
        }
        LostGame();
    }

    void LostGame()
    {
        Debug.Log("The deck is empty.\n Game Over.");
    }

    void WonGame()
    {
        Debug.Log("The game is won!");
    }

    bool CheckDeck()
    {
        int similarAmount = 1;
        char suite = hand[0].Last();
        for (int i = 1; i < hand.Count; i++)
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
        similarAmount = 1;
        suite = hand[1].Last();
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

    string GetHand(List<string> hand)
    {
        string currentHand = "";
        foreach (string card in hand)
        {
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
