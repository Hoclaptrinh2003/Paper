using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : UiControll, Iobserver
{

    [SerializeField] private GameObject Bubble;



    private void Awake()
    {
        RegisterObserver();
        CanControllUi(true);

    }


    private void RegisterObserver()
    {
        SubJect.Register(this);

    }

    private void NotificationCompleteWater()
    {
        SubJect.Notify("CompleteWater_Step1");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mount_1"))
        {
            TimePlay += Time.deltaTime;
        }

     


        CheckTime();
    }

    private void CheckTime()
    {
        if (TimePlay >= TimeEnd / 3)
        {
            Bubble.SetActive(true);

        }




        if (TimePlay >= TimeEnd)
        {
            FadeOut();

            NotificationCompleteWater();
        }
    }

}
