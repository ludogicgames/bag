using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{

    public string cardName;
    public string cardDescription;

    [Tooltip("0 = instant effect. 2+ the number of cards needed to trigger")]
    public int accumulative = 0;

    [Tooltip("On trigger draw X cards 0 = no effect")]
    public int cardsToDrag = 0;


    public Sprite cardImage;
  
    
    /*  public enum CardName
    {
        dynamite,
        tnt,
        barrel,
        pass,
        inYourFace,
        gunPowder,
        gift,
        discard


    } */
}
