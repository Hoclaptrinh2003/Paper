using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comb : UiControll, Iobserver
{
    [SerializeField] private RectTransform targetPoint1;
    [SerializeField] private RectTransform targetPoint2;
    [SerializeField] private Image img;

    private Coroutine blinkCoroutine;

    protected virtual void Awake()
    {
        AwakeComponent();
    }

    private void OnEnable()
    {
        MoveToTagetTowPoint();

    }

    protected override void SaveOriginPo()
    {
        initialPosition = targetPoint2.anchoredPosition;

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
            if (TimePlay >= TimeEnd)
            {
                CanControllUi(false);
                FadeOutForGameObjectChild(GameObject.Find("Bottle"));
                FadeOutForGameObjectChild(GameObject.Find("Comb"));
                SubJect.Notify("EndStep2");

            }
        }


        CheckTime();
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    TimePlay = 0;
    //}

    private void CheckTime()
    {





        if (TimePlay >= TimeEnd)
        {
            CanControllUi(false);
            TimePlay = 0;
            SubJect.Notify("CompleteComb_Step2");
        }
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

        SubJect.Register(this);
    }


    public void onNotify(string key)
    {
        if (key == "CompleteBottle_Step2")
        {
           CanControllUi(true);
            StartBlinkingImage();

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
