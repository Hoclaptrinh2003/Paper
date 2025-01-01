using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scissors : UiControll, Iobserver
{

   
    [SerializeField] private Image img;
    [SerializeField] private GameObject Scissors_left;
    [SerializeField] private GameObject Scissors_right;
    private bool isCall = false;
    protected override void Start()
    {
        base.Start();   
        CanControllUi(true);
        AwakeComponent();
    }


    protected override void Update()
    {
        base.Update();
        GameObject[] hairObjects = GameObject.FindGameObjectsWithTag("Hair");

        if (hairObjects.Length == 0  && isCall == false)
        {
            isCall = true;
            FadeOutForGameObjectChild(Scissors_right);
            FadeOutForGameObjectChild(Scissors_left);
            SubJect.Notify("CompleteScissors_Step2");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hair"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;   
            Destroy(collision.gameObject,2f);
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
        if (key == "")
        {
            CanControllUi(true);
        }



    }

}
