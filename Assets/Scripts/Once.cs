using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Once : MonoBehaviour
{
    public string astra = "";
    public string astra_check = "";

    //Button bools represent the coordinate conditions that have to be met
    public bool monkeyPos;
    public bool birdPos;
    public bool dragonPos;


    //These bools represent what Jutsu will be printed to Astra
    public bool monkeyJutsu = true;
    public bool birdJutsu = true;
    public bool dragonJutsu = true;


    //Jutsu Moves
    public bool shadowCloneJutsu = false;
    public bool sexyJutsu = false;
    public bool fireJutsu = false;


    //Game Logic
    public bool moveOn = true;


    public void buttonCheck()
    {

        //This itself is monkey Jutsu -----------------
        if (Input.GetKey("a") && Input.GetKey("s") /*&& monkeyJutsu && monkeyPos*/ && moveOn) //If angle is 90 or something 
        {

            astra += "Monkey"; 
            //monkeyJutsu = false; 
            moveOn = false;
        }


        if (!Input.GetKey("s") || !Input.GetKey("a") /*|| !monkeyJutsu && !monkeyPos*/) 
        {
            monkeyJutsu = true;

        }

        //Monkey Pos seperate from Monkey Jutsu
        if (Input.GetKey("h")) 
        {
            //print("Pos");
            monkeyPos = true;
        }

        else
        {
            monkeyPos = false;
        }
        //Monkey Jutsu -------------




        if (Input.GetKeyDown("c"))
        {
            astra = "";
        }



    }



    void FixedUpdate()
    {
        print("Astra: " + astra);
        buttonCheck();
        if (moveOn == true) //If angle is 0 (Centered) 
        {
            if (astra_check != astra)
            {
                astra_check = astra;
            }
        }

        if (Input.GetKey("l")) //If angle is 0 (Centered)  
        {
            moveOn = true;
        }


        if (astra == "MonkeyMonkeyMonkey")
        {
            //print("Alpha");
            //monkeyJutsu = true;
            //sphereClones.Clear();
            astra_check = ""; 
            moveOn = true;
            shadowCloneJutsu = true;
            print("SHADOW: " + shadowCloneJutsu);
            //astra = "";
            //something = true;
        }

        if (astra == "BirdBirdBird")
        {
            astra_check = "";
            moveOn = true;
            sexyJutsu = true;

            //print("Beta");
            //birdJutsu = true;

        }

        if (astra == "DragonDragonDragon")
        {
            fireJutsu = true;
        }

        //if(Input.GetKey("q"))
        //{
        //    var emberOut = 0;
        //    IEnumerator WaitDestroy()
        //    {
        //        foreach(GameObject clone in sphereClones)
        //        {

        //            yield return new WaitForSeconds(.5f);
        //            emberOut += 1;
        //            Destroy(sphereClones[emberOut]);
        //        }

        //    }

        //    StartCoroutine(WaitDestroy());
        //}
    }
}




