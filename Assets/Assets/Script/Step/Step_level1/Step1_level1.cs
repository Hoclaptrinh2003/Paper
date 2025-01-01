using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step1_level1 : Singleton<Step1_level1>, Iobserver
{
    public List<GameObject> Step1_lv1;

    private void Awake()
    {
        RegisterObserver();
    }

    public void PlayBrush()
    {
        Step1_lv1[0].SetActive(true);
        Step1_lv1[1].SetActive(true);
        Step1_lv1[2].SetActive(true);
        Step1_lv1[3].SetActive(false);
        BtnManager.Instance.Btn_Step[0].SetActive(false);    
    }

    private void EndPlayBrush()
    {

      Step1_lv1[1].SetActive(false);
      Step1_lv1[3].SetActive(true);

    }


    public void PlayWater()
    {
        Step1_lv1[4].SetActive(true);

    }

    public void EndPlayWater()
    {
        Step1_lv1[6].SetActive(true);
        Step1_lv1[7].SetActive(false);
        Step1_lv1[5].SetActive(true);
        Step1_lv1[3].SetActive(false);
    }

    private void RegisterObserver()
    {
        SubJect.Register(this);

    }

    public void onNotify(string key)
    {
        if (key == "CompleteBrush_Step1")
        {
            EndPlayBrush();
            PlayWater();
            Debug.Log("Đã xong đánh răng");
        }

        if (key == "CompleteWater_Step1")
        {
            EndPlayWater();
            Debug.Log("Đã xong rửa miệng");
        }

    }


}
