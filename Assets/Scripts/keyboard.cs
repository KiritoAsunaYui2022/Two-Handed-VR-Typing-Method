using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public bool RangleBool;
    public bool LangleBool;

    public bool confirmCancel;

    public float letterStringLength; 


    void Start()
    {

        RangleBool = false;
        LangleBool = false;

        confirmCancel = false;

        letterStringLength = 15f; 
    }

    public void cancel()
    {
        if (RangleBool == false && LangleBool == false)
        {
            if (letterStringLength >= 10f)
            {
                confirmCancel = true;
                print("Intention Active");                 

                if (Input.GetKey("a"))
                {
                    //Do code A  
                    confirmCancel = false;
                    print("Cleared");                     
                }

                else if (Input.GetKey("b"))
                {
                    //Cancel intention 
                    confirmCancel = false;
                    print("Intention Ended"); 
                }
            }

            else
            {
                //Do code A 
            }
        }
    }

    public float cancelStage; 
    public void stage()
    {

        //press down and lsl > 10, cs = 1, message and confirmCancel = true 
        //!press down and cs = 1, cs = 2
        //press down and cs = 2, cancel OR press alt down and cs = 2, confirmCancel = false and cs = 0f 

        if (letterStringLength >= 10f && !confirmCancel)
        {
            cancelStage = 1f; 
            //Message 
            confirmCancel = true; 
        }

        if (!Input.GetKey("a") && cancelStage == 1f && confirmCancel)
        {
            cancelStage = 2f; 
        }

        if (Input.GetKey("a") && cancelStage == 2f && confirmCancel)
        {
            print("Cancelled");
            cancelStage = 0f;
            confirmCancel = false;
            letterStringLength = 0f; 
        }
    }


    void Update()
    {
        //if (confirmCancel)
        //{
        //    cancel(); 
        //}

        //if (Input.GetKey("a"))
        //{
        //    cancelStage = 1f; 
        //    cancel(); 
        //}        

        if (Input.GetKey("a"))
        {
            stage();
        }

        if (confirmCancel)
        {
            stage(); 
        }    

        if (Input.GetKey("b"))
        {
            letterStringLength = 15f; 
        }
    }
}
