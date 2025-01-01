using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Brush : UiControll,Iobserver
{
    [SerializeField] private GameObject Cream;
    [SerializeField] private GameObject Bubble;

    private void Awake()
    {
        RegisterObserver();
    }

    protected override void Start()
    {
        base.Start();

    }

    private void OnEnable()
    {
        StartCoroutine(TimeToCanPlayBrush());
    }


    private void OnDisable()
    {
        CanControllUi(false);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mount_2"))
        {
            TimePlay += Time.deltaTime;
        }

        CheckTime();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        TimePlay = 0;
    }


    private void NotificationCompleteBrush()
    {
        SubJect.Notify("CompleteBrush_Step1");
    }


    private void RegisterObserver()
    {
        SubJect.Register(this);

    }

  

    private IEnumerator TimeToCanPlayBrush()
    {
        yield return new WaitForSeconds(1.5f);
        CanControllUi(true);
    }

    private void CheckTime()
    {
        if (TimePlay >= TimeEnd / 3)
        {
            Bubble.SetActive(true);

        }




        if (TimePlay >= TimeEnd)
        {
            Debug.Log("Chuyển");
            FadeOut();
            FadeOutForGameObjectChild(Cream);
            NotificationCompleteBrush();
            ReturnOriginPo();
            CanControllUi(false);

        }
    }
 

    public void onNotify(string key)
    {


    }

}
