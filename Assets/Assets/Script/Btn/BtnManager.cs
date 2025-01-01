using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : Singleton<BtnManager>
{

    public Button Btn_Step1_lvel1;
    public List<GameObject> Btn_Step; 


    private void Start()
    {
        Btn_Step1_lvel1.onClick.AddListener(Step1_level1.Instance.PlayBrush);
    }





}
