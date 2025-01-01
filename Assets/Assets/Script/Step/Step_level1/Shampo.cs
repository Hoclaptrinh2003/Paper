using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shampo : UiControll, Iobserver
{
    [SerializeField] private GameObject Bumble1;
    [SerializeField] private GameObject Bumble2;
    [SerializeField] private GameObject Bumble3;
    [SerializeField] private GameObject Bumble4;

    private Image bumble1Image;
    private Image bumble2Image;
    private Image bumble3Image;
    private Image bumble4Image;

    private float fadeSpeed = 0.5f;

    private void Awake()
    {
        SubJect.Register(this);
        CanControllUi(true);

        bumble1Image = Bumble1.GetComponent<Image>();
        bumble2Image = Bumble2.GetComponent<Image>();
        bumble3Image = Bumble3.GetComponent<Image>();
        bumble4Image = Bumble4.GetComponent<Image>();

        if (bumble1Image != null) bumble1Image.color = new Color(bumble1Image.color.r, bumble1Image.color.g, bumble1Image.color.b, 0);
        if (bumble2Image != null) bumble2Image.color = new Color(bumble2Image.color.r, bumble2Image.color.g, bumble2Image.color.b, 0);
        if (bumble3Image != null) bumble3Image.color = new Color(bumble3Image.color.r, bumble3Image.color.g, bumble3Image.color.b, 0);
        if (bumble4Image != null) bumble4Image.color = new Color(bumble4Image.color.r, bumble4Image.color.g, bumble4Image.color.b, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Face"))
        {
            StartCoroutine(GradualFadeIn(bumble1Image, bumble2Image));
        }

        if (collision.CompareTag("FaceDown"))
        {
            StartCoroutine(GradualFadeIn(bumble3Image, bumble4Image));
        }
    }

    private IEnumerator GradualFadeIn(Image bumbleImage1, Image bumbleImage2)
    {
        while (bumbleImage1.color.a < 1f || bumbleImage2.color.a < 1f)
        {
            if (bumbleImage1 != null)
            {
                float newAlpha1 = Mathf.Min(bumbleImage1.color.a + fadeSpeed * Time.deltaTime, 1f);
                bumbleImage1.color = new Color(bumbleImage1.color.r, bumbleImage1.color.g, bumbleImage1.color.b, newAlpha1);
            }

            if (bumbleImage2 != null)
            {
                float newAlpha2 = Mathf.Min(bumbleImage2.color.a + fadeSpeed * Time.deltaTime, 1f);
                bumbleImage2.color = new Color(bumbleImage2.color.r, bumbleImage2.color.g, bumbleImage2.color.b, newAlpha2);
            }

            yield return null;
        }

        if (bumble1Image.color.a == 1f && bumble2Image.color.a == 1f && bumble3Image.color.a == 1f && bumble4Image.color.a == 1f)
        {
            FadeOut();
            SubJect.Notify("CompleteShampo_Step3");
        }
    }
}
