//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; 

//public class Alphabet : MonoBehaviour
//{
//    //If you can, animate it floating down onto your controller while having it ghost in 
//    public ControllerAxis axis; 

//    public string currentLetterSelected = ""; //astra 
//    public string letterOutput = ""; //astra_check 
//    private bool isCenter;
//    private bool deletePressed;
//    private bool spacePressed;

//    public float angle; 

//    public Text output;
//    public Text lOutput;
//    public Text isCenterText;
//    public Text OVR;


//    public void Start()
//    {
//        deletePressed = false;
//        spacePressed = false;
        
//    }
//    public void space()
//    {
        
//        currentLetterSelected += "|";
//        isCenter = false;

//    }
//    public void deleteLetter()
//    {
        
//        currentLetterSelected = currentLetterSelected.Substring(0, letterOutput.Length - 1);
//        isCenter = false;

//    }

//    public void deSelectLetter()
//    {
//        print("LetterOutput: " + letterOutput.Length);
//        print("currentSelected: " + currentLetterSelected.Length);

//        isCenter = true; 

//        if (currentLetterSelected.Length > letterOutput.Length)
//        {
//            currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1); 
//            print("Replace"); 
//        }
//    }
//    public void letterSelect()
//    {
//        ////Switch to Switch funtion, use if statements for proof of concept 
//        //if (axis.angle <= 27.6923077f && axis.angle > 0f) 
//        //{
//        //    deSelectLetter();

//        //    if (isCenter)
//        //    {
//        //        print("a");

//        //        currentLetterSelected += "a";
//        //        isCenter = false;
//        //    }

//        //}        

//        //if (axis.angle <=55.3846154f && axis.angle > 27.6923077f)
//        //{
//        //    deSelectLetter(); 

//        //    if (isCenter)
//        //    {
//        //        print("b"); 
//        //        currentLetterSelected += "b"; 
//        //        isCenter = false;
//        //    }
//        //} 
//        if (isCenter)
//        {
//            switch (angle)
//            {
//                case float angle when angle <= 27.6923077f && angle > 0f: // a
//                    deSelectLetter();

//                    if (isCenter)
//                    {
//                        currentLetterSelected += "a";
//                        //letterOutput += "a"; 
//                        //isCenter = false;
//                    }
//                    break;

//                case float angle when angle <= 55.3846154f && angle > 27.6923077f:
//                    deSelectLetter();

//                    if (isCenter)
//                    {
//                        currentLetterSelected += "b";
//                        isCenter = false;
//                    }
//                    break;

//                default:
//                    print("Not on pallet");
//                    break;
//            }
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
//        }
//    }


//    void Update() 
//    {
//        angle = axis.angle;
//        letterSelect();
//        print(isCenter); 

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

//        OVR.text = "Pressed: " + deletePressed; 
//        isCenterText.text = "isCenter: " + isCenter; 
//        lOutput.text = "Curr: " + currentLetterSelected;
//        output.text = "Output: " + letterOutput;
         
//    }
//}
