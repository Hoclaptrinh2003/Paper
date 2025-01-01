using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2_level1 : Singleton<Step2_level1>, Iobserver
{
    public GameObject Sock;
    public GameObject Bottle;
    public GameObject Comb;
    public GameObject FaceFlip;
    public GameObject Face;
    public GameObject Scissorsl;
    private void Awake()
    {
        RegisterObserver();
    }


    public void PlayBottle()
    {
        Sock.SetActive(true);   
        Bottle.SetActive(true);
        Comb.SetActive(true);   
    }

    public void PlayFaceFlip()
    {
        Face.SetActive(false);
        FaceFlip.SetActive(true);   
    }

    public void EndPlayFaceFlip()
    {
        Face.SetActive(true);
        FaceFlip.SetActive(false);
    }



    public void PlayCutHair()
    {
        Scissorsl.SetActive(true);  
    }

 


    private void RegisterObserver()
    {
        SubJect.Register(this);

    }


    public void onNotify(string key)
    {
        

        if (key == "CompleteWater_Step1")
        {
            PlayBottle();   
            
        }

        if (key == "CompleteComb_Step2")
        {
            PlayCutHair();

        }

        if(key == "CompleteScissors_Step2")
        {
            PlayFaceFlip();
        }
         if(key == "EndStep2")
        {
            EndPlayFaceFlip();
        }
    }

}
