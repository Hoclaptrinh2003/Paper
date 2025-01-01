using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : UiControll, Iobserver
{
    [SerializeField] private GameObject Bald;

    private void Awake()
    {
        SubJect.Register(this);
        CanControllUi(true);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Face"))
        {
            TimePlay += Time.deltaTime;


            if (TimePlay >= TimeEnd/2)
            {
                Bald.SetActive(true);
                Step3_level1.Instance.Cry.SetActive(true);
                Step3_level1.Instance.Eye_strong.SetActive(true);
                Step3_level1.Instance.Mount_4.SetActive(true);
                Step1_level1.Instance.Step1_lv1[1].SetActive(false);
                Step1_level1.Instance.Step1_lv1[3].SetActive(false);
                Step1_level1.Instance.Step1_lv1[5].SetActive(false);


            }


            if (TimePlay >= TimeEnd)
            {
                SubJect.Notify("CompleteMagnifyingGlass_Step3");
                CanControllUi(false);
                FadeOut();
                FadeOutForGameObjectChild(Bald);
                ReturnOriginPo();

            }
        }
    }


 

}
