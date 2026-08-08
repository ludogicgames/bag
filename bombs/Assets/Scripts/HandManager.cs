using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public Transform handTransform; //Root

    public float fanSpreadAngle = 5f;
    public int fanSpreadXOffset = 50;
    public int fanSpreadYOffset = 50;

    public List<GameObject> cardInHand = new List<GameObject>();
    void Start()
    {
        
    }

    
    public void AddCardsToHand(Card cardData)
    {
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardInHand.Add(newCard);
        UpdateHandVisuals();
        newCard.GetComponent<CardDisplay>().cardData = cardData;
    }
    public void UpdateHandVisuals()
    {
        int cardCount = cardInHand.Count;
        

        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (fanSpreadAngle * ((i + 0.5f) - (cardCount /2f)));
            cardInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, -rotationAngle);
            cardInHand[i].GetComponent<CardDisplay>().ChangeBaseRotation(Quaternion.Euler(0f, 0f, -rotationAngle));
            cardInHand[i].transform.localPosition = new Vector3 (((i + 0.5f) - (cardCount / 2f))* fanSpreadXOffset, -Mathf.Abs((i+0.5f) - (cardCount / 2f)) * fanSpreadYOffset, 0);
        }

    }
  
    public void Update() {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
           
        } 
    }

}
       
