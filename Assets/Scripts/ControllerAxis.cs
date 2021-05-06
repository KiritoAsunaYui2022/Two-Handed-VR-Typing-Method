using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerAxis : MonoBehaviour
{
    //Left Controller 
    private Vector2 Laxis; 
    private float Lcont; //I just chose a random name 
    public float Langle; // Used in Alphabet 

    //Universal 
    private float circle; 

    //Right Controller 
    private Vector2 Raxis;
    private float Rcont; //I just chose a random name 
    public float Rangle; // Used in Alphabet 

    //For testing
    public Text LaxisText;
    public Text angleText;


    //Some documentation 
//Laxis and Raxis are Vector2's that ustilize inverse tangent (See Unit Circle) of an x and y coordinate and with some Mathf magic is 
//converted into an angle that is used for the Character Pallets 

    public void SenseAxis()
    {

//Left Controller 
        //Public GameObject [L] Controller not needed because already calls for PrimaryThumbstick (Left Controller). Although, might assign for other types of controller. 
        Laxis = (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)); 

        //This version might be a better result, idk tho 
        Lcont = (Mathf.Atan2(Laxis.x, Laxis.y) * Mathf.Rad2Deg);
        //cont = (Mathf.Acos(Laxis.x) * Mathf.Rad2Deg * Mathf.Sign(Laxis.y)); 

        //Negative number test to add 360 onto cont when negative. Lcont can only go to +-180 so when it goes negative, 360 is added to produce the true angle. 
        if (Lcont < 0f)
        {
            circle = 360f; 
        }

        else
        {
            circle = 0f; 
        }

        //Comment this when testing with the keyboard buttons 
        Langle = Lcont + circle; 

        //angleText.text = "Angle; " + (Langle);


//Right Controller 
        //Public GameObject [R] Controller not needed because already calls for PrimaryThumbstick (Left Controller). Although, might assign for other types of controller. 
        Raxis = (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick));

        //This version might be a better result, idk tho 
        Rcont = (Mathf.Atan2(Raxis.x, Raxis.y) * Mathf.Rad2Deg);
        //cont = (Mathf.Acos(Laxis.x) * Mathf.Rad2Deg * Mathf.Sign(Laxis.y)); 

        //Negative number test to add 360 onto cont when negative. Rcont can only go to +-180 so when it goes negative, 360 is added to produce the true angle. 
        if (Rcont < 0f)
        {
            circle = 360f;
        }

        else
        {
            circle = 0f;
        }

        //Comment this when testing with the keyboard buttons 
        Rangle = Rcont + circle;

    }

    void Update()
    {
        SenseAxis();
    }
}
