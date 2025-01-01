using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public abstract class UiControll : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] protected bool isDragging = false;
    [SerializeField] protected bool CanControll = false;
    [SerializeField] protected Vector2 initialPosition;
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected float TimePlay;
    [SerializeField] protected float TimeEnd;

    [SerializeField] protected Image imageToFade;
    protected virtual void Start()
    {
        StartComponent();
        SaveOriginPo();

      
    }

    protected virtual void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CanControll == false)
        {
            return;
        }
        Debug.Log("Chạm tay");
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CanControll == false)
        {
            return;
        }
        if (isDragging)
        {
            MoveUI(eventData.position);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //if (CanControll == false)
        //{
        //    return;
        //}
        isDragging = false;
        Debug.Log("Thả tay");
        ReturnOriginPo();   
       
    }


    protected void ReturnOriginPo()
    {
        rectTransform.DOAnchorPos(initialPosition, 0.5f);

    }

    private void MoveUI(Vector2 touchPosition)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(touchPosition);
        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
    }

    protected virtual void SaveOriginPo()
    {
        initialPosition = rectTransform.anchoredPosition;
    }

    private void StartComponent()
    {
        imageToFade = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    protected void FadeOut()
    {
        if (imageToFade != null)
        {
            imageToFade.DOFade(0f, 1).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }

    protected void FadeOutForGameObjectChild(GameObject gameObject)
    {
        Image image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.DOFade(0f, 1).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }


    }

 
    protected void CanControllUi(bool canPlay)
    {
        CanControll = canPlay;
    }

}
