using UnityEngine;
using UnityEngine.EventSystems;


public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerDownHandler, IPointerEnterHandler
{

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private HandManager handManager;
    
    private BoardManager boardManager;

    public bool isCardDragable = false;

    public void SetHandManager(HandManager manager)
    {
        handManager = manager;
    }
    public void SetBoardManager(BoardManager board)
    {
        boardManager = board;
    }


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        handManager = GetComponentInParent<HandManager>();
      
    }
    #region Drag Sistem
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (!isCardDragable) return;


        originalPosition = rectTransform.anchoredPosition;

        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = false; // para que no se choque consigo misma al soltar
        Debug.Log("Se activa on beging drag");

      
           
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isCardDragable) return;
        // Movemos la carta según el delta del mouse, ajustado por el scale del canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = true;

        

       

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, canvas.worldCamera, out Vector2 localPoint);

        float canvasHeight = canvasRect.rect.height;

        if (localPoint.y > -canvasHeight / 6f)
        {
            isCardDragable = false;
            handManager.RemoveCardFromHand(gameObject);

        }
        else
        {
            handManager.UpdateHandVisuals();


        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
    #endregion

}
