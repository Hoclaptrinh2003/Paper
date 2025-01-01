using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class Bottle : UiControll, Iobserver
{
    [SerializeField] private RectTransform targetPoint1;
    [SerializeField] private RectTransform targetPoint2;
    [SerializeField] private Image img;  
    [SerializeField] private GameObject Bubble;
    [SerializeField] private BoxCollider2D Box2D;

    private Coroutine blinkCoroutine; 
    protected override void Update()
    {
        base.Update();
        BubbleControll();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hair"))
        {
            TimePlay += Time.deltaTime;
        }

        if (collision.CompareTag("FaceFlip"))
        {
            TimePlay += Time.deltaTime;
        }



        CheckTime();
    }

    private void CheckTime()
    {
        if (TimePlay >= TimeEnd)
        {
            CanControllUi(false);
            SubJect.Notify("CompleteBottle_Step2");
            TimePlay = 0;
        }
    }

    private void BubbleControll()
    {
        if (isDragging)
        {
            Bubble.SetActive(true);
        }
        else
        {
            Bubble.SetActive(false);
        }
    }

    protected virtual void Awake()
    {
        AwakeComponent();
    }

    protected override void SaveOriginPo()
    {
        initialPosition = targetPoint2.anchoredPosition;
    }

    private void OnEnable()
    {
        MoveToTagetTowPoint();
    }

    protected void MoveToTagetTowPoint()
    {
        if (targetPoint1 != null && targetPoint2 != null)
        {
            rectTransform.DOAnchorPos(targetPoint1.anchoredPosition, 1f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    rectTransform.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.FastBeyond360)
                        .OnComplete(() =>
                        {
                            StartBlinkingImage();
                            CanControllUi(true);
                            Step2_level1.Instance.Sock.SetActive(false);
                            Box2D.enabled = true;
                            rectTransform.DOAnchorPos(targetPoint2.anchoredPosition, 1f)
                                .SetEase(Ease.OutQuad);
                        });
                });
        }
    }

    private void AwakeComponent()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        if (img == null)
        {
            img = GetComponent<Image>();
        }

        Box2D = GetComponent<BoxCollider2D>();
        Box2D.enabled = false;
        SubJect.Register(this);
    }

    public void onNotify(string key)
    {
        if (key == "CompleteComb_Step2")
        {
            CanControllUi(true);
        }
    }

    private void StartBlinkingImage()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine); 
        }

        blinkCoroutine = StartCoroutine(BlinkImage());
    }


    private IEnumerator BlinkImage()
    {
        Color white = Color.white;
        Color gray = new Color(219f / 255f, 219f / 255f, 219f / 255f, 1f); 

        while (isDragging == false)
        {
           
            img.color = white; 
            yield return new WaitForSeconds(0.5f); 

            img.color = gray;
            yield return new WaitForSeconds(0.5f); 
        }
        img.color = white;
    }
}
