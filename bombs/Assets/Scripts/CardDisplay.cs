using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;

    public TMP_Text title;
    public TMP_Text description;
   

    public Image cardImage;

    void Start()
    {
        UpdateCardDisplay();
    }

    
    public void UpdateCardDisplay()
    {
        title.text = cardData.cardName;
        description.text = cardData.cardDescription;
        cardImage.sprite = cardData.cardImage;
    }
}
