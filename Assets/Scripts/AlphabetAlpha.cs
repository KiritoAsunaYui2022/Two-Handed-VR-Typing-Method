using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class AlphabetAlpha : MonoBehaviour
{
    //If you can, animate it floating down onto your controller while having it ghost in 
    public ControllerAxis axis;

    public string currentLetterSelected = ""; //astra 
    //public string letterOutput = ""; //astra_check 
    //private bool isCenter; //When both controllers are centered 
    private bool deletePressed;
    private bool spacePressed;
    private bool CAPSLOCK;
    private bool Shift;
    private bool Numbers;
    private bool SpecialCharacters;
    private bool RangleBool;
    private bool LangleBool;
    private bool confirmCancel; 

    //I'm not sure how I feel about this Shift method. So when you activate Shift, ShiftStage == 1f, then once you select a letter, ShiftStage == 2f, then when Langle == 0f ... 
    //... and it ShiftStage == 2f, Shift = false and ShiftStage = 0f. It's the circle of shifting and the only way I could think of. Please simply this... works for now 
    private float ShiftStage;

    //Angles resctive to their Controllers 
    public float Langle;
    public float Rangle;

    //
    public float CancelStage; 

    //Used for deselecting a character and replacing it with another when another letter is selected before realtive Thumbstick is centered which confirms the letter   
    public float letterStringLength;

    //Images 
    public Image AMuppercase;
    public Image amLowercase;
    public Image NZuppercase;
    public Image nzLowercase; 
    public Image NumbersImage;
    public Image SpecialCharactersImage; 

    //Texts 
    public TextMeshProUGUI output; //I don't know why this has to be different from TextMeshPro but it is 
    public TextMeshPro ShiftText;
    public TextMeshPro CAPStext;
    public TextMeshPro NumbersText;
    public TextMeshPro SpecialCharactersText;
    public TextMeshProUGUI confirmCancelText;
    public TextMeshPro yes;
    public TextMeshPro enterText; 
    public TextMeshPro no;
    public TextMeshPro cancelText; 
    public TextMeshProUGUI letterLengthText; 

    //Indicators 
    public GameObject indicator;
        //Right 
    public Transform R1; 
    public Transform R2;
    public Transform R3;
    public Transform R4;
    public Transform R5;
    public Transform R6;
    public Transform R7;
    public Transform R8;
    public Transform R9;
    public Transform R10;
    public Transform R11;
    public Transform R12;
    public Transform R13;
        //Left 
    public Transform L1;
    public Transform L2;
    public Transform L3;
    public Transform L4;
    public Transform L5;
    public Transform L6;
    public Transform L7;
    public Transform L8;
    public Transform L9;
    public Transform L10;
    public Transform L11;
    public Transform L12;
    public Transform L13; 


    public void Start()
    {
        deletePressed = false;
        spacePressed = false;
        CAPSLOCK = false;
        Shift = false;
        Numbers = false;
        SpecialCharacters = false;
        RangleBool = false;
        LangleBool = false;
        confirmCancel = false; 
        letterStringLength = 0f;
        ShiftStage = 0f;
        CancelStage = 0f; 

        AMuppercase.enabled = false;
        amLowercase.enabled = true;

        NZuppercase.enabled = false;
        nzLowercase.enabled = true;
        
        NumbersImage.enabled = false;
        SpecialCharactersImage.enabled = false;

        confirmCancelText.text = "Are you sure you want to cancel?";
        confirmCancelText.enabled = false;

        yes.text = "Yes";
        yes.enabled = false; 

        no.text = "No";
        no.enabled = false; 

    }

    //This class prevents the clashing of Rangle and Langle when they try to print for currentLetterSelected, otherwise if both thumbsticks are being used you can't type 
    public void RangleLangle()
    {
        if (Rangle != 0f && LangleBool == false)
        {
            RangleBool = true;
        }

        else
        {
            RangleBool = false;
        }

        if (Langle != 0f && RangleBool == false)
        {
            LangleBool = true;
        }

        else
        {
            LangleBool = false;
        }
    }


    public void space()
    {
        //This is because space() will include the selected letter that isn't wanted into the output, so both Langle/Rangle need to be centered 
        if (RangleBool == false && LangleBool == false && confirmCancel == false)
        {
            currentLetterSelected += " ";
            letterStringLength = currentLetterSelected.Length;
        }
        
    }

    public void deleteLetter()
    {
        //Same thing as space() 
        if (RangleBool == false && LangleBool == false && confirmCancel == false)
        {
            currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1);
            if (letterStringLength > 0f)
            {
                letterStringLength = letterStringLength - 1f;
            }
        }

         
    }

    //This essentially takes currentLetterSelected and compares it to the actual letterStringLength. This is used for when you haven't clicked on a letter to select it. 
    public void deSelectLetter()
    {
        if (currentLetterSelected.Length > letterStringLength)
        {
            currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1); 
        }
    }

    //A lot depends on this confirm cancel because if the prompt comes up, everything must stop functioning before you make a decision 
    //A constant check is in the Update function 
    /*Similar to ShiftStage, the cancel class/method/function/whatever flows through the stages starting when the letterStringLength is greater or equal to 5 in length,
      then once the primaryIndexTrigger (the cancel button) is released it goes to the second stage which prompts the message, and readies/readys (idk) for any input. 
      The third stages are when user will choose to clear the text [currentLetterSelected] using the cancel button again, or to cancel the clearing by the enter button
      which is the secondaryIndexTrigger button. 
    */ 
    public void cancel()
    {
        if (RangleBool == false && LangleBool == false)
        {
            //First Stage, enabling the prompt and stopping any other input 
            if (letterStringLength >= 5f && !confirmCancel)
            { 
                CancelStage = 1f; 
                confirmCancel = true;
                cancelText.enabled = false;
                enterText.enabled = false;
                yes.enabled = true;
                no.enabled = true; 
                confirmCancelText.enabled = true;
            }

            //If below 5 characters, currentLetterSelected is just cleared 
            else if (letterStringLength < 5f && !confirmCancel)
            {
                currentLetterSelected = "";
                letterStringLength = 0f;
            }

            //Second Stage, a position for the user to choose either to clear the text (currentLetterSelected) or to cancel and continue inputting characters 
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 0f && CancelStage == 1f && confirmCancel)
            {
                CancelStage = 2f;
                cancelText.enabled = false;
                enterText.enabled = false;
                yes.enabled = true;
                no.enabled = true;
                confirmCancelText.enabled = true;
            }

            
            //Third Stage-A, clearing the currentLetterSelected has been chosen 
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1f && CancelStage == 2f && confirmCancel) 
            {
                CancelStage = 0f; 
                confirmCancel = false;
                cancelText.enabled = true;
                enterText.enabled = true;
                yes.enabled = false;
                no.enabled = false;
                confirmCancelText.enabled = false;
                currentLetterSelected = "";
                letterStringLength = 0f;
            }

            //Third Stage-B, cancelling clearing the currentLetterSelected has been chosen and you can now continue to input more characters 
            else if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1f && CancelStage == 2f && confirmCancel)
            {
                CancelStage = 0f;
                confirmCancel = false;
                cancelText.enabled = true;
                enterText.enabled = true;
                yes.enabled = false;
                no.enabled = false;
                confirmCancelText.enabled = false; 
            }
            //Your Additional Code here such as closing the typing system down 
        }
    }

    //For when the text (currentLetterSelected) is to be used for a purpose like searching something or typing a name or in chat 
    public void enter()
    {
        //Same thing as space() 
        if (RangleBool == false && LangleBool == false && confirmCancel == false)
        {
            //Your custom Code here 
        }
    }

    //Get ready for a L O N G list of letters! 
    public void letterSelect()
    {
        //If [R] Controller is centered then [L] Controller can access its letters 
        if (LangleBool && !confirmCancel)
        {
            switch (Langle)
            {
                //aA - mM 
                case float Langle when Langle <= 27.6923077f && Langle > 0f: // Layers: a, A  

                    //Indicator transforms it's position to the relative transform L1-L13
                    indicator.transform.position = L1.transform.position; 
                    if (!Shift || !CAPSLOCK) //Layer One, a 
                    {
                        deSelectLetter();
                        currentLetterSelected += "a"; 
                    }

                    if (Shift || CAPSLOCK) //Layer Two, A 
                    {
                        deSelectLetter();
                        currentLetterSelected += "A"; 
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 55.3846154f && Langle > 27.6923077f: // Layers: b, B  

                    indicator.transform.position = L2.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, b 
                    {
                        deSelectLetter();
                        currentLetterSelected += "b";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, B  
                    {
                        deSelectLetter();
                        currentLetterSelected += "B";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 83.0769231f && Langle > 55.3846154f: // Layers: c, C   

                    indicator.transform.position = L3.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, c 
                    {
                        deSelectLetter();
                        currentLetterSelected += "c";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, C   
                    {
                        deSelectLetter();
                        currentLetterSelected += "C";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 110.7692308f && Langle > 83.0769231f: // Layers: d, D    

                    indicator.transform.position = L4.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, d  
                    {
                        deSelectLetter();
                        currentLetterSelected += "d";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, D   
                    {
                        deSelectLetter();
                        currentLetterSelected += "D";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 138.4615385f && Langle > 110.7692308f: // Layers: e, E    

                    indicator.transform.position = L5.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, e  
                    {
                        deSelectLetter();
                        currentLetterSelected += "e";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, E    
                    {
                        deSelectLetter();
                        currentLetterSelected += "E";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 166.1538462f && Langle > 138.4615385f: // Layers: f, F    

                    indicator.transform.position = L6.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, f  
                    {
                        deSelectLetter();
                        currentLetterSelected += "f";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, F    
                    {
                        deSelectLetter();
                        currentLetterSelected += "F";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 193.8461539f && Langle > 166.1538462f: // Layers: g, G    

                    indicator.transform.position = L7.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, g  
                    {
                        deSelectLetter();
                        currentLetterSelected += "g";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, G    
                    {
                        deSelectLetter();
                        currentLetterSelected += "G";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 221.5384616f && Langle > 193.8461539f: // Layers: h, H    

                    indicator.transform.position = L8.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, h  
                    {
                        deSelectLetter();
                        currentLetterSelected += "h";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, H    
                    {
                        deSelectLetter();
                        currentLetterSelected += "H";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 249.2307693f && Langle > 221.5384616f: // Layers: i, I    

                    indicator.transform.position = L9.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, i  
                    {
                        deSelectLetter();
                        currentLetterSelected += "i";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, I    
                    {
                        deSelectLetter();
                        currentLetterSelected += "I";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 276.923077f && Langle > 249.2307693f: // Layers: j, J    

                    indicator.transform.position = L10.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, j  
                    {
                        deSelectLetter();
                        currentLetterSelected += "j";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, J    
                    {
                        deSelectLetter();
                        currentLetterSelected += "J";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 304.6153847f && Langle > 276.923077f: // Layers: k, K    

                    indicator.transform.position = L11.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, k  
                    {
                        deSelectLetter();
                        currentLetterSelected += "k";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, K    
                    {
                        deSelectLetter();
                        currentLetterSelected += "K";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 332.3076924f && Langle > 304.6153847f: // Layers: l, L    

                    indicator.transform.position = L12.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, l  
                    {
                        deSelectLetter();
                        currentLetterSelected += "l";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, L    
                    {
                        deSelectLetter();
                        currentLetterSelected += "L";
                        
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 360f && Langle > 332.3076924f: // Layers: m, M    

                    indicator.transform.position = L13.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, m  
                    {
                        deSelectLetter();
                        currentLetterSelected += "m";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, M    
                    {
                        deSelectLetter();
                        currentLetterSelected += "M";
                        
                        ShiftStage = 2f;
                    }
                    break;

                default:
                    print("Character Not On Pallet");
                    break;
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
            {
                letterStringLength = currentLetterSelected.Length;
            }
        }

        if (RangleBool && !confirmCancel)
        {
            switch (Rangle)
            {
                case float Rangle when Rangle <= 27.6923077f && Rangle > 0f: // Layers: n, N, 1, !  

                    //Indicator transforms it's position to the relative transform R1-R13 
                    indicator.transform.position = R1.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, n  
                    {
                        deSelectLetter();
                        currentLetterSelected += "n";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, N  
                    {
                        deSelectLetter();
                        currentLetterSelected += "N";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 1 
                    {
                        deSelectLetter();
                        currentLetterSelected += "1";
                         
                    }

                    if (SpecialCharacters) //Layer Four, ! 
                    {
                        deSelectLetter();
                        currentLetterSelected += "!";
                         
                    }
                    break;

                case float Rangle when Rangle <= 55.3846154f && Rangle > 27.6923077f: // Layers: o, O, 2, ?  

                    indicator.transform.position = R2.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, o   
                    {
                        deSelectLetter();
                        currentLetterSelected += "o";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, O  
                    {
                        deSelectLetter();
                        currentLetterSelected += "O";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 2 
                    {
                        deSelectLetter();
                        currentLetterSelected += "2";
                        
                    }

                    if (SpecialCharacters) //Layer Four, ?  
                    {
                        deSelectLetter();
                        currentLetterSelected += "?";
                        
                    }
                    break;

                case float Rangle when Rangle <= 83.0769231f && Rangle > 55.3846154f: // Layers: p, P, 3, @   

                    indicator.transform.position = R3.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, p   
                    {
                        deSelectLetter();
                        currentLetterSelected += "p";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, P  
                    {
                        deSelectLetter();
                        currentLetterSelected += "P";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 3 
                    {
                        deSelectLetter();
                        currentLetterSelected += "3";
                        
                    }

                    if (SpecialCharacters) //Layer Four, @  
                    {
                        deSelectLetter();
                        currentLetterSelected += "@";
                        
                    }
                    break;

                case float Rangle when Rangle <= 110.7692308f && Rangle > 83.0769231f: // Layers: q, Q, 4, #   

                    indicator.transform.position = R4.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, q   
                    {
                        deSelectLetter();
                        currentLetterSelected += "q";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Q  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Q";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 4 
                    {
                        deSelectLetter();
                        currentLetterSelected += "4";
                        
                    }

                    if (SpecialCharacters) //Layer Four, #  
                    {
                        deSelectLetter();
                        currentLetterSelected += "#";
                        
                    }
                    break;

                case float Rangle when Rangle <= 138.4615385f && Rangle > 110.7692308f: // Layers: r, R, 5, %   

                    indicator.transform.position = R5.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, r   
                    {
                        deSelectLetter();
                        currentLetterSelected += "r";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, R  
                    {
                        deSelectLetter();
                        currentLetterSelected += "R";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 5 
                    {
                        deSelectLetter();
                        currentLetterSelected += "5";
                        
                    }

                    if (SpecialCharacters) //Layer Four, %  
                    {
                        deSelectLetter();
                        currentLetterSelected += "%";
                        
                    }
                    break;

                case float Rangle when Rangle <= 166.1538462f && Rangle > 138.4615385f: // Layers: s, S, 6, _   

                    indicator.transform.position = R6.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, s   
                    {
                        deSelectLetter();
                        currentLetterSelected += "s";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, S  
                    {
                        deSelectLetter();
                        currentLetterSelected += "S";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 6 
                    {
                        deSelectLetter();
                        currentLetterSelected += "6";
                        
                    }

                    if (SpecialCharacters) //Layer Four, _  
                    {
                        deSelectLetter();
                        currentLetterSelected += "_";
                        
                    }
                    break;

                case float Rangle when Rangle <= 193.8461539f && Rangle > 166.1538462f: // Layers: t, T, 7, )    

                    indicator.transform.position = R7.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, t   
                    {
                        deSelectLetter();
                        currentLetterSelected += "t";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, T  
                    {
                        deSelectLetter();
                        currentLetterSelected += "T";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 7 
                    {
                        deSelectLetter();
                        currentLetterSelected += "7";
                        
                    }

                    if (SpecialCharacters) //Layer Four, )  
                    {
                        deSelectLetter();
                        currentLetterSelected += ")";
                        
                    }
                    break;

                case float Rangle when Rangle <= 221.5384616f && Rangle > 193.8461539f: // Layers: u, U, 8, (    

                    indicator.transform.position = R8.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, u   
                    {
                        deSelectLetter();
                        currentLetterSelected += "u";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, U  
                    {
                        deSelectLetter();
                        currentLetterSelected += "U";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 8 
                    {
                        deSelectLetter();
                        currentLetterSelected += "8";
                        
                    }

                    if (SpecialCharacters) //Layer Four, (  
                    {
                        deSelectLetter();
                        currentLetterSelected += "(";
                        
                    }
                    break;

                case float Rangle when Rangle <= 249.2307693f && Rangle > 221.5384616f: // Layers: v, V, 9, =     

                    indicator.transform.position = R9.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, v   
                    {
                        deSelectLetter();
                        currentLetterSelected += "v";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, V  
                    {
                        deSelectLetter();
                        currentLetterSelected += "V";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 9 
                    {
                        deSelectLetter();
                        currentLetterSelected += "9";
                        
                    }

                    if (SpecialCharacters) //Layer Four, =  
                    {
                        deSelectLetter();
                        currentLetterSelected += "=";
                        
                    }
                    break;

                case float Rangle when Rangle <= 276.923077f && Rangle > 249.2307693f: // Layers: w, W, 0, /      

                    indicator.transform.position = R10.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, w   
                    {
                        deSelectLetter();
                        currentLetterSelected += "w";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, W  
                    {
                        deSelectLetter();
                        currentLetterSelected += "W";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 0 
                    {
                        deSelectLetter();
                        currentLetterSelected += "0";
                        
                    }

                    if (SpecialCharacters) //Layer Four, /  
                    {
                        deSelectLetter();
                        currentLetterSelected += "/";
                        
                    }
                    break;

                case float Rangle when Rangle <= 304.6153847f && Rangle > 276.923077f: // Layers: x, X, ., *       

                    indicator.transform.position = R11.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, x   
                    {
                        deSelectLetter();
                        currentLetterSelected += "x";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, X  
                    {
                        deSelectLetter();
                        currentLetterSelected += "X";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, .  
                    {
                        deSelectLetter();
                        currentLetterSelected += ".";
                        
                    }

                    if (SpecialCharacters) //Layer Four, *  
                    {
                        deSelectLetter();
                        currentLetterSelected += "*";
                        
                    }
                    break;

                case float Rangle when Rangle <= 332.3076924f && Rangle > 304.6153847f: // Layers: y, Y, ,, -       

                    indicator.transform.position = R12.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, y   
                    {
                        deSelectLetter();
                        currentLetterSelected += "y";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Y  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Y";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, ,  
                    {
                        deSelectLetter();
                        currentLetterSelected += ",";
                        
                    }

                    if (SpecialCharacters) //Layer Four, -  
                    {
                        deSelectLetter();
                        currentLetterSelected += "-";
                        
                    }
                    break;

                case float Rangle when Rangle <= 360f && Rangle > 332.3076924f: // Layers: z, Z, $, +       

                    indicator.transform.position = R13.transform.position;
                    if (!Shift || !CAPSLOCK) //Layer One, z   
                    {
                        deSelectLetter();
                        currentLetterSelected += "z";
                        
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Z  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Z";
                        
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, $   
                    {
                        deSelectLetter();
                        currentLetterSelected += "$";
                        
                    }

                    if (SpecialCharacters) //Layer Four, +   
                    {
                        deSelectLetter();
                        currentLetterSelected += "+";
                        
                    }
                    break;

                default:
                    print("Character Not On Pallet");
                    break;
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
            {
                letterStringLength = currentLetterSelected.Length;
            }
        }
    }

    //I think I could have done this whole thing better because I'm going to have to check for true/false later on when I could have done it in one. For now its a POC. 
    public void buttonSelect()
    {
        if (!confirmCancel)
        {
            //Backspace 
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 1f && deletePressed)
            {
                deleteLetter();
                deletePressed = false;
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 0f)
            {
                deletePressed = true;
            }

            //Space 
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 1f && spacePressed)
            {
                space();
                spacePressed = false;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 0f)
            {
                spacePressed = true;
            }


            //CAPS LICK 
            if (OVRInput.GetDown(OVRInput.Button.One) && !CAPSLOCK) //CAPSLOCK = true, CAPS: On 
            {
                CAPSLOCK = true;
            }

            else if (OVRInput.GetDown(OVRInput.Button.One) && CAPSLOCK) //CAPSLOCK = false, CAPS: Off 
            {
                CAPSLOCK = false;
            }

            //Shift 
            if (OVRInput.GetDown(OVRInput.Button.Two) && !Shift)
            {
                Shift = true;
                ShiftStage = 1f;
            }

            else if (OVRInput.GetDown(OVRInput.Button.Two) && Shift)
            {
                Shift = false;
                ShiftStage = 0f;
            }

            //Numbers 
            if (OVRInput.GetDown(OVRInput.Button.Three) && !Numbers)
            {
                Numbers = true;
            }

            else if (OVRInput.GetDown(OVRInput.Button.Three) && Numbers)
            {
                Numbers = false;
            }

            //Special Characters 
            if (OVRInput.GetDown(OVRInput.Button.Four) && !SpecialCharacters)
            {
                SpecialCharacters = true;
            }

            else if (OVRInput.GetDown(OVRInput.Button.Four) && SpecialCharacters)
            {
                SpecialCharacters = false;
            }

            //Enter 
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1f)
            {
                enter();
            }

            //Cancel 
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1f)
            {
                cancel();
            }


            //If CAPS LICK IS ON 
            if (CAPSLOCK)
            {
                Shift = false;
                ShiftStage = 0f;

                CAPStext.text = "CAPS: On";

                AMuppercase.enabled = true;
                amLowercase.enabled = false;

                NZuppercase.enabled = true;
                nzLowercase.enabled = false;
            }

            else
            {
                CAPStext.text = "CAPS: Off";

                AMuppercase.enabled = false;
                amLowercase.enabled = true;

                NZuppercase.enabled = false;
                nzLowercase.enabled = true;
            }


            //If Shift Is On 
            if (Shift)
            {
                if (!CAPSLOCK)
                {
                    ShiftText.text = "Shift: On";

                    AMuppercase.enabled = true;
                    NZuppercase.enabled = true;

                    amLowercase.enabled = false;
                    nzLowercase.enabled = false;
                }
            }

            else
            {
                ShiftText.text = "Shift: Off";

                if (!CAPSLOCK)
                {
                    AMuppercase.enabled = false;
                    amLowercase.enabled = true;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = true;
                }
            }

            //!f speci@! ch@r@cters @re ()n
            if (SpecialCharacters)
            {
                SpecialCharactersText.text = "Special Characters: On";
                Numbers = false;

                if (CAPSLOCK || Shift)
                {
                    AMuppercase.enabled = true;
                    amLowercase.enabled = false;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = false;

                    SpecialCharactersImage.enabled = true;
                }

                else
                {
                    AMuppercase.enabled = false;
                    amLowercase.enabled = true;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = false;

                    SpecialCharactersImage.enabled = true;
                }

            }

            else
            {
                SpecialCharactersText.text = "Special Characters: Off";

                if (CAPSLOCK || Shift)
                {
                    AMuppercase.enabled = true;
                    amLowercase.enabled = false;

                    NZuppercase.enabled = true;
                    nzLowercase.enabled = false;

                    SpecialCharactersImage.enabled = false;
                }

                else
                {
                    AMuppercase.enabled = false;
                    amLowercase.enabled = true;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = true;

                    SpecialCharactersImage.enabled = false;
                }
            }

            //1f act1vated number5  
            if (Numbers)
            {
                NumbersText.text = "Numbers: On";
                SpecialCharacters = false;

                if (CAPSLOCK || Shift)
                {
                    AMuppercase.enabled = true;
                    amLowercase.enabled = false;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = false;

                    NumbersImage.enabled = true;
                }

                else
                {
                    NumbersImage.enabled = true;

                    AMuppercase.enabled = false;
                    amLowercase.enabled = true;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = false;

                    NumbersImage.enabled = true;
                }
            }

            else
            {
                NumbersText.text = "Numbers: Off";

                if (CAPSLOCK || Shift)
                {
                    AMuppercase.enabled = true;
                    amLowercase.enabled = false;

                    NZuppercase.enabled = true;
                    nzLowercase.enabled = false;

                    NumbersImage.enabled = false;
                }

                else
                {
                    AMuppercase.enabled = false;
                    amLowercase.enabled = true;

                    NZuppercase.enabled = false;
                    nzLowercase.enabled = true;

                    NumbersImage.enabled = false;
                }
            }
        }

        

        //First check to see if PrimaryThumb is centered 
        if (Langle == 0f && Rangle == 0f)
        { 
            //THESE COMMENTS BELOW ARE FOR THE OLD METHOD 
            //Essentially when Langle's and Rangle's angles equal 0, meaning the joysticks are centered, then the selected letter is added to the output.  
            //letterStringLength = currentLetterSelected.Length;


            indicator.SetActive(false);

            deSelectLetter(); 

            if (ShiftStage == 2f)
            {
                Shift = false;
                ShiftStage = 0f;
            }
        }

        else
        {
            indicator.SetActive(true); 
        }
    }
        



    void Update()
    {
        Langle = axis.Langle;
        Rangle = axis.Rangle;
        RangleLangle(); 
        letterSelect();
        buttonSelect();


        if (confirmCancel)
        {
            cancel();
        }





        //Keyboard when testing without headset 
        //if (Input.GetKeyDown("r") && !CAPSLOCK)
        //{
        //    CAPSLOCK = true; 
        //}

        //else if (Input.GetKeyDown("r") && CAPSLOCK)
        //{
        //    CAPSLOCK = false;
        //}

        //if (Input.GetKey("a"))
        //{
        //    axis.Langle = 27.5f;
        //}

        //if (Input.GetKey("b"))
        //{
        //    axis.Langle = 50f;
        //}

        //if (Input.GetKey("c"))
        //{
        //    axis.Langle = 0f;
        //}

        ////Override 
        //if (Input.GetKeyDown("i"))
        //{
        //    deSelectLetter();
        //}

        ////Input check to see if you can backspace, maybe 
        //if (Input.GetKeyDown("q") && //isCenter)
        //{
        //    deleteLetter();
        //}

        //if (Input.GetKeyDown("s") && //isCenter)
        //{
        //    space();
        //}

        output.text = "Output: " + currentLetterSelected;
        //letterLengthText.text = "LetterLength: " + letterStringLength; 
    }
}
