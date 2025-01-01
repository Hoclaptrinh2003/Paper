using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassageComb : UiControll, Iobserver
{
    private void Awake()
    {
        SubJect.Register(this);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Face"))
        {
            TimePlay += Time.deltaTime;



            if (TimePlay >= TimeEnd/2)
            {
                Step3_level1.Instance.Eye_relax.SetActive(true);
                Step3_level1.Instance.Eye_strong.SetActive(false);


            }



            if (TimePlay >= TimeEnd)
            {
                SubJect.Notify("CompleteMassageComb_Step3");
                CanControllUi(false);
                ReturnOriginPo();

            }
        }
    }

  
    public void onNotify(string key)
    {
        if (key == "EndStep2")
        {
            CanControllUi(true);
        }
    }




}
