using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class MoveToTaget : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform targetPoint1;
    [SerializeField] private RectTransform targetPoint2;
    [SerializeField] private Image img;


    protected virtual void Awake()
    {
        AwakeComponent();

    }

    // Hàm di chuyển được sử dụng nếu vật thể có một điểm đến

    protected void MoveToTagetOnePoint()
    {
        if (rectTransform != null && targetPoint1 != null)
        {
            rectTransform.DOAnchorPos(targetPoint1.anchoredPosition, 2f)
                .SetEase(Ease.OutQuad)  
                .OnComplete(() =>
                {
                    Fadeout();
                });
        }
    }


    // Hàm di chuyển được sử dụng nếu vật thể có hai điểm đến
    protected void MoveToTagetTowPoint()
    {
        if (targetPoint1 != null && targetPoint2 != null)
        {
            rectTransform.DOAnchorPos(targetPoint1.anchoredPosition, 1f)
                .SetEase(Ease.OutQuad)  
                .OnComplete(() =>
                {
                    rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.FastBeyond360)
                        .OnComplete(() =>
                        {
                            rectTransform.DOAnchorPos(targetPoint2.anchoredPosition, 1f)
                                .SetEase(Ease.OutQuad);  
                        });
                });
        }
    }

    //Giảm dần độ anpla vật thể về o rồi ẩn đi
    protected void Fadeout()
    {
        if (img != null)
        {
            img.DOFade(0f, 1f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }


    // Get các Component ở hàm Awake
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


    }




}
