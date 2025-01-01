using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3_level1 : Singleton<Step3_level1>, Iobserver
{




    public GameObject Eye_relax;
    public GameObject Eye_strong;
    public GameObject Mount_4;
    public GameObject Shampo;
    public GameObject Bumble;
    public GameObject Device;

    public GameObject MagnifyingGlass;
    public GameObject Cry;
    public GameObject img_background;


    private void Awake()
    {
        RegisterObserver();
    }
    private void RegisterObserver()
    {
        SubJect.Register(this);

    }
    public void onNotify(string key)
    {
        if (key == "CompleteMassageComb_Step3")
        {
            MagnifyingGlass.SetActive(true); 
        }

        if (key == "CompleteMagnifyingGlass_Step3")
        {
            Shampo.SetActive(true); 
        }

        if (key == "CompleteShampo_Step3")
        {
            Bumble.SetActive(false);
            Device.SetActive(true);
            StartCoroutine(DevicesWithDelay());
        }

    }


    private IEnumerator DevicesWithDelay()
    {
      

            yield return new WaitForSeconds(5.2f);
            img_background.SetActive(true);
    }

}
