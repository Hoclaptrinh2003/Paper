using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toothpaste : MoveToTaget, Iobserver
{

    protected override void Awake()
    {
        base.Awake();

    }

    private void OnEnable()
    {
        MoveToTagetOnePoint();

    }




}
