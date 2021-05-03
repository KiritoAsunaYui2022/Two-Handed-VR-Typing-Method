//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class AlphabetRework : MonoBehaviour
//{
//    //If you can, animate it floating down onto your controller while having it ghost in 
//    public ControllerAxis axis;

//    public string currentLetterSelected = ""; //astra 
//    public string letterOutput = ""; //astra_check 
//    private bool isCenter;
//    private bool deletePressed;
//    private bool spacePressed;
//    private bool CAPSLOCK;
//    private bool Shift;

//    //I hate this Shift method. So when you activate Shift, ShiftStage == 1f, then once you select a letter, ShiftStage == 2f, then when Langle == 0f ... 
//    //... and it ShiftStage == 2f, Shift = false and ShiftStage = 0f. It's the circle of shifting and the only way I could think of. Please simply this... works for now 
//    private float ShiftStage; 

//    public float angle;

//    //Used for deselecting a character and replacing it with another when another letter is selected before realtive Thumbstick is centered which confirms the letter   
//    public float letterStringLength; 

//    public Text output;
//    public Text lOutput;
//    public Text isCenterText;
//    public Text OVR;


//    public void Start()
//    {
//        deletePressed = false;
//        spacePressed = false;
//        letterStringLength = 0f;
//        CAPSLOCK = false;
//        Shift = false;
//        ShiftStage = 0f;  
//    } 
//    public void space()
//    {

//        currentLetterSelected += "|";
//        isCenter = false;

//    }
//    public void deleteLetter()
//    { 
//        currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1); 
//        isCenter = false;

//    }

//    public void deSelectLetter()
//    {
//        if (currentLetterSelected.Length > letterStringLength)
//        {
//            currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1);
//            print("deSelectLetter");
//        }
//    }

//    public void letterSelect()
//    { 
//        switch (angle)
//        { 
//            case float angle when angle <= 27.6923077f && angle > 0f: // Layers: a, A  
                
//                if (!Shift || !CAPSLOCK) //Layer One, a 
//                {
//                    deSelectLetter();
//                    currentLetterSelected += "a"; 
//                    isCenter = false;
//                }

//                if (Shift || CAPSLOCK) //Layer Two, A 
//                {
//                    deSelectLetter();
//                    currentLetterSelected += "A"; 
//                    isCenter = false;
//                    ShiftStage = 2f; 
//                }
//                break; 

//            case float angle when angle <= 55.3846154f && angle > 27.6923077f: // b 
//                deSelectLetter();
//                currentLetterSelected += "b";
//                isCenter = false;
//                break;

//            default:
//                print("Character Not On Pallet");
//                break;
//        }
        

//        //Backspace 
//        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 1f && deletePressed)
//        {
//            deleteLetter();
//            deletePressed = false;
//        }

//        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 0f)
//        {
//            deletePressed = true;
//        }

//        //Space 
//        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 1f && spacePressed)
//        {
//            space();
//            spacePressed = false;
//        }

//        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 0f)
//        {
//            spacePressed = true;
//        }

//        //First check to see if PrimaryThumb is centered 
//        if (axis.angle == 0f)
//        {
//            isCenter = true;
//            print("String: " + currentLetterSelected.Length + ", Float: " + letterStringLength);
//            letterStringLength = currentLetterSelected.Length; 
            
//            if (ShiftStage == 2f)
//            {
//                Shift = false;
//                ShiftStage = 0f; 
//            }
//        }
//    }


//    void Update()
//    {
//        angle = axis.angle;
//        letterSelect();

//        //CAPS LICK 
//        if (OVRInput.GetDown(OVRInput.Button.One) && !CAPSLOCK)
//        {
//            CAPSLOCK = true; 
//        }

//        else if (OVRInput.GetDown(OVRInput.Button.One) && CAPSLOCK)
//        {
//            CAPSLOCK = false; 
//        }


//        //Shift 
//        if (OVRInput.GetDown(OVRInput.Button.Two) && !Shift)
//        {
//            Shift = true; 
//            ShiftStage = 1f; 
//        }

//        else if (OVRInput.GetDown(OVRInput.Button.Two) && Shift)
//        {
//            Shift = false;
//            ShiftStage = 0f; 
//        }


//        //KEYBOARD 
//        if (Input.GetKeyDown("r") && !CAPSLOCK)
//        {
//            CAPSLOCK = true; 
//        }

//        else if (Input.GetKeyDown("r") && CAPSLOCK)
//        {
//            CAPSLOCK = false; 
//        }

//        if (Input.GetKey("a"))
//        {
//            axis.angle = 27.5f;
//        }

//        if (Input.GetKey("b"))
//        {
//            axis.angle = 50f;
//        }

//        if (Input.GetKey("c"))
//        {
//            axis.angle = 0f;
//        }

//        //Override 
//        if (Input.GetKeyDown("i"))
//        {
//            deSelectLetter();
//        }

//        //Input check to see if you can backspace, maybe 
//        if (Input.GetKeyDown("q") && isCenter)
//        {
//            deleteLetter();
//        }

//        if (Input.GetKeyDown("s") && isCenter)
//        {
//            space();
//        }

//        //if (isCenter == true)
//        //{
//        //    //currentLetterSelected += letterOutput;
//        //    if (letterOutput != currentLetterSelected)
//        //    {
//        //        //print("Astra: " + astra);
//        //        letterOutput = currentLetterSelected;
//        //    }
//        //}

//        OVR.text = "CAPS: " + OVRInput.Get(OVRInput.Button.PrimaryThumbstick); 
//        isCenterText.text = "isCenter: " + isCenter;
//        lOutput.text = "Curr: " + currentLetterSelected;
//        output.text = "Output: " + letterOutput;

//    }
//}
