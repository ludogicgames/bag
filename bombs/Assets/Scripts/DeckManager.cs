using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{

    public List<Card> cardsToDraw = new List<Card>();

    public List<Card> discard = new List<Card>();







    public void Start()
    {
        Shuffle();
    }

    public Card DrawCard()
    {
        if (cardsToDraw.Count == 0) DiscardToDeck();


        Card cardToReturn = cardsToDraw[cardsToDraw.Count - 1];
        cardsToDraw.RemoveAt(cardsToDraw.Count - 1);


        return cardToReturn;
    }
    public void Shuffle()
    {
        for (int i = cardsToDraw.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Card temp = cardsToDraw[i];
            cardsToDraw[i] = cardsToDraw[randomIndex];
            cardsToDraw[randomIndex] = temp;
        }

    }
    public void DiscardToDeck()
    {
        cardsToDraw = discard;
        discard.Clear();
        Shuffle();

    }


}
