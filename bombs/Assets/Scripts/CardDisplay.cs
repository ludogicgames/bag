using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour
{

    [Header("Card Info - Scriptable object")]
    [Tooltip("Scriptable object instance of the card")]
    public Card cardData;

    [Header("Prefab elements - DO NOT MODIFIED")]
    public TMP_Text title;
    public TMP_Text description;
    public Image cardImage;

    [Header("Idle Animation")]
    public bool hasIdleAnimation = false;
    [Range(0f, 1f)]
    public float scaleModifyIntensity = 0.05f;
    [Range(0f, 20f)]
    public float rotationIntensity = 10f;
    public float scaleCicleTime = 1f;
    public float rotationCicleTime = 1f;


    // Values for base
    private Quaternion baseRotation;
    private Vector3 baseScale;

    void Start()
    {
        
        baseRotation = transform.localRotation;
        baseScale = transform.localScale;

        UpdateCardDisplay();
        
    }
    private void Update()
    {
       if (hasIdleAnimation) CodeAnimation();
    }

    #region Aesthetics

        public void UpdateCardDisplay()
        {
            title.text = cardData.cardName;
            description.text = cardData.cardDescription;
            cardImage.sprite = cardData.cardImage;
        }
        public void ChangeBaseRotation(Quaternion newRotation)
        {
            baseRotation = newRotation;
     
        }

        public void CodeAnimation()
        {
            //calculate angle from 2 pi
            float waveScaleAmplitud = (Time.time / scaleCicleTime) * Mathf.PI * 2f;

            transform.localScale = new Vector3(
              baseScale.x,
              baseScale.y + baseScale.y * scaleModifyIntensity * Mathf.Sin(waveScaleAmplitud),
              baseScale.z
            );

            float waveRotationAmplitud = (Time.time / rotationCicleTime) * Mathf.PI * 2f;

            transform.localRotation = baseRotation * Quaternion.Euler(
                0f,
                0f,
                rotationIntensity * Mathf.Sin(waveRotationAmplitud)
            );




            /*
            // Normalize sin from -1 - 1 to 0-1
            float normalized = (Mathf.Sin(waveAmplitud) + 1f )/2f;

            // Apply the Intensity
            float scaleFactor = Mathf.Lerp(1f - scaleModifyIntensity, 1f, normalized);

            //Aply Scale transform
            transform.localScale = new Vector3(
                baseScale.x,
                baseScale.y * scaleFactor,
                baseScale.z
            );
            */
        }

    #endregion

    
}
