using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alphabet : MonoBehaviour
{
    //If you can, animate it floating down onto your controller while having it ghost in 
    public ControllerAxis axis;

    public string currentLetterSelected = ""; //astra 
    //public string letterOutput = ""; //astra_check 
    private bool isCenter;
    private bool deletePressed;
    private bool spacePressed;
    private bool CAPSLOCK;
    private bool Shift;
    private bool Numbers;
    private bool SpecialCharacters; 

    //I hate this Shift method. So when you activate Shift, ShiftStage == 1f, then once you select a letter, ShiftStage == 2f, then when Langle == 0f ... 
    //... and it ShiftStage == 2f, Shift = false and ShiftStage = 0f. It's the circle of shifting and the only way I could think of. Please simply this... works for now 
    private float ShiftStage;

    //Angles resctive to their Controllers 
    public float Langle;
    public float Rangle; 

    //Used for deselecting a character and replacing it with another when another letter is selected before realtive Thumbstick is centered which confirms the letter   
    public float letterStringLength;

    //Images 
    public Image AMuppercase;
    public Image amLowercase;
    public Image NZuppercase;
    public Image nzLowercase; 
    public Image NumbersImage;
    public Image SpecialCharactersImage; 

    public Text output;
    public Text ShiftText;
    public Text CAPStext;
    public Text NumbersText;
    public Text SpecialCharactersText;
    //public Text soOn; 
    //public Text lOutput;
    //public Text isCenterText;
    //public Text OVR;


    public void Start()
    {
        deletePressed = false;
        spacePressed = false;
        CAPSLOCK = false;
        Shift = false;
        Numbers = false;
        SpecialCharacters = false;
        letterStringLength = 0f;
        ShiftStage = 0f;

        //CAPStext.text = "CAPS: Off";
        //ShiftText.text = "Shift: Off";
        //NumbersText.text = "Num: Off";
        //SpecialCharactersText.text = "Char: Off";

        AMuppercase.enabled = false;
        amLowercase.enabled = true;

        NZuppercase.enabled = false;
        nzLowercase.enabled = true;
        
        NumbersImage.enabled = false;
        SpecialCharactersImage.enabled = false; 

    }
    public void space()
    {
        currentLetterSelected += " ";
        isCenter = false;
    }
    public void deleteLetter()
    {
        currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1);
        isCenter = false; 
    }

    public void deSelectLetter()
    {
        if (currentLetterSelected.Length > letterStringLength)
        {
            currentLetterSelected = currentLetterSelected.Remove(currentLetterSelected.Length - 1);
            print("deSelectLetter");
        }
    }

    public void cancel()
    {
        currentLetterSelected = ""; 
        //Additional code here such as closing the typing system down 
    }

    public void enter()
    {
        //Code here 
    }

    //Get ready for a L O N G list of letters! 
    public void letterSelect()
    {
        //If [R] Controller is centered then [L] Controller can access its letters 
        if (Rangle == 0f)
        {
            switch (Langle)
            {
                //aA - mM 
                case float Langle when Langle <= 27.6923077f && Langle > 0f: // Layers: a, A  

                    if (!Shift || !CAPSLOCK) //Layer One, a 
                    {
                        deSelectLetter();
                        currentLetterSelected += "a";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, A 
                    {
                        deSelectLetter();
                        currentLetterSelected += "A";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 55.3846154f && Langle > 27.6923077f: // Layers: b, B  

                    if (!Shift || !CAPSLOCK) //Layer One, b 
                    {
                        deSelectLetter();
                        currentLetterSelected += "b";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, B  
                    {
                        deSelectLetter();
                        currentLetterSelected += "B";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 83.0769231f && Langle > 55.3846154f: // Layers: c, C   

                    if (!Shift || !CAPSLOCK) //Layer One, c 
                    {
                        deSelectLetter();
                        currentLetterSelected += "c";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, C   
                    {
                        deSelectLetter();
                        currentLetterSelected += "C";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 110.7692308f && Langle > 83.0769231f: // Layers: d, D    

                    if (!Shift || !CAPSLOCK) //Layer One, d  
                    {
                        deSelectLetter();
                        currentLetterSelected += "d";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, D   
                    {
                        deSelectLetter();
                        currentLetterSelected += "D";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 138.4615385f && Langle > 110.7692308f: // Layers: e, E    

                    if (!Shift || !CAPSLOCK) //Layer One, e  
                    {
                        deSelectLetter();
                        currentLetterSelected += "e";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, E    
                    {
                        deSelectLetter();
                        currentLetterSelected += "E";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 166.1538462f && Langle > 138.4615385f: // Layers: f, F    

                    if (!Shift || !CAPSLOCK) //Layer One, f  
                    {
                        deSelectLetter();
                        currentLetterSelected += "f";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, F    
                    {
                        deSelectLetter();
                        currentLetterSelected += "F";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 193.8461539f && Langle > 166.1538462f: // Layers: g, G    

                    if (!Shift || !CAPSLOCK) //Layer One, g  
                    {
                        deSelectLetter();
                        currentLetterSelected += "g";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, G    
                    {
                        deSelectLetter();
                        currentLetterSelected += "G";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 221.5384616f && Langle > 193.8461539f: // Layers: h, H    

                    if (!Shift || !CAPSLOCK) //Layer One, h  
                    {
                        deSelectLetter();
                        currentLetterSelected += "h";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, H    
                    {
                        deSelectLetter();
                        currentLetterSelected += "H";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 249.2307693f && Langle > 221.5384616f: // Layers: i, I    

                    if (!Shift || !CAPSLOCK) //Layer One, i  
                    {
                        deSelectLetter();
                        currentLetterSelected += "i";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, I    
                    {
                        deSelectLetter();
                        currentLetterSelected += "I";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 276.923077f && Langle > 249.2307693f: // Layers: j, J    

                    if (!Shift || !CAPSLOCK) //Layer One, j  
                    {
                        deSelectLetter();
                        currentLetterSelected += "j";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, J    
                    {
                        deSelectLetter();
                        currentLetterSelected += "J";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 304.6153847f && Langle > 276.923077f: // Layers: k, K    

                    if (!Shift || !CAPSLOCK) //Layer One, k  
                    {
                        deSelectLetter();
                        currentLetterSelected += "k";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, K    
                    {
                        deSelectLetter();
                        currentLetterSelected += "K";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 332.3076924f && Langle > 304.6153847f: // Layers: l, L    

                    if (!Shift || !CAPSLOCK) //Layer One, l  
                    {
                        deSelectLetter();
                        currentLetterSelected += "l";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, L    
                    {
                        deSelectLetter();
                        currentLetterSelected += "L";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                case float Langle when Langle <= 360f && Langle > 332.3076924f: // Layers: m, M    

                    if (!Shift || !CAPSLOCK) //Layer One, m  
                    {
                        deSelectLetter();
                        currentLetterSelected += "m";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, M    
                    {
                        deSelectLetter();
                        currentLetterSelected += "M";
                        isCenter = false;
                        ShiftStage = 2f;
                    }
                    break;

                default:
                    print("Character Not On Pallet");
                    break;
            }
        }

        if (Langle == 0)
        {
            switch (Rangle)
            {
                case float Rangle when Rangle <= 27.6923077f && Rangle > 0f: // Layers: n, N, 1, !  

                    if (!Shift || !CAPSLOCK) //Layer One, n  
                    {
                        deSelectLetter();
                        currentLetterSelected += "n";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, N  
                    {
                        deSelectLetter();
                        currentLetterSelected += "N";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 1 
                    {
                        deSelectLetter();
                        currentLetterSelected += "1";
                        isCenter = false; 
                    }

                    if (SpecialCharacters) //Layer Four, ! 
                    {
                        deSelectLetter();
                        currentLetterSelected += "!";
                        isCenter = false; 
                    }
                    break;

                case float Rangle when Rangle <= 55.3846154f && Rangle > 27.6923077f: // Layers: o, O, 2, ?  

                    if (!Shift || !CAPSLOCK) //Layer One, o   
                    {
                        deSelectLetter();
                        currentLetterSelected += "o";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, O  
                    {
                        deSelectLetter();
                        currentLetterSelected += "O";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 2 
                    {
                        deSelectLetter();
                        currentLetterSelected += "2";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, ?  
                    {
                        deSelectLetter();
                        currentLetterSelected += "?";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 83.0769231f && Rangle > 55.3846154f: // Layers: p, P, 3, @   

                    if (!Shift || !CAPSLOCK) //Layer One, p   
                    {
                        deSelectLetter();
                        currentLetterSelected += "p";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, P  
                    {
                        deSelectLetter();
                        currentLetterSelected += "P";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 3 
                    {
                        deSelectLetter();
                        currentLetterSelected += "3";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, @  
                    {
                        deSelectLetter();
                        currentLetterSelected += "@";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 110.7692308f && Rangle > 83.0769231f: // Layers: q, Q, 4, #   

                    if (!Shift || !CAPSLOCK) //Layer One, q   
                    {
                        deSelectLetter();
                        currentLetterSelected += "q";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Q  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Q";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 4 
                    {
                        deSelectLetter();
                        currentLetterSelected += "4";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, #  
                    {
                        deSelectLetter();
                        currentLetterSelected += "#";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 138.4615385f && Rangle > 110.7692308f: // Layers: r, R, 5, %   

                    if (!Shift || !CAPSLOCK) //Layer One, r   
                    {
                        deSelectLetter();
                        currentLetterSelected += "r";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, R  
                    {
                        deSelectLetter();
                        currentLetterSelected += "R";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 5 
                    {
                        deSelectLetter();
                        currentLetterSelected += "5";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, %  
                    {
                        deSelectLetter();
                        currentLetterSelected += "%";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 55.3846154f && Rangle > 27.6923077f: // b 
                    deSelectLetter();
                    currentLetterSelected += "b";
                    isCenter = false;
                    break;

                case float Rangle when Rangle <= 166.1538462f && Rangle > 138.4615385f: // Layers: s, S, 6, _   

                    if (!Shift || !CAPSLOCK) //Layer One, s   
                    {
                        deSelectLetter();
                        currentLetterSelected += "s";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, S  
                    {
                        deSelectLetter();
                        currentLetterSelected += "S";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 6 
                    {
                        deSelectLetter();
                        currentLetterSelected += "6";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, _  
                    {
                        deSelectLetter();
                        currentLetterSelected += "_";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 193.8461539f && Rangle > 166.1538462f: // Layers: t, T, 7, )    

                    if (!Shift || !CAPSLOCK) //Layer One, t   
                    {
                        deSelectLetter();
                        currentLetterSelected += "t";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, T  
                    {
                        deSelectLetter();
                        currentLetterSelected += "T";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 7 
                    {
                        deSelectLetter();
                        currentLetterSelected += "7";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, )  
                    {
                        deSelectLetter();
                        currentLetterSelected += ")";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 221.5384616f && Rangle > 193.8461539f: // Layers: u, U, 8, (    

                    if (!Shift || !CAPSLOCK) //Layer One, u   
                    {
                        deSelectLetter();
                        currentLetterSelected += "u";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, U  
                    {
                        deSelectLetter();
                        currentLetterSelected += "U";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 8 
                    {
                        deSelectLetter();
                        currentLetterSelected += "8";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, (  
                    {
                        deSelectLetter();
                        currentLetterSelected += "(";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 249.2307693f && Rangle > 221.5384616f: // Layers: v, V, 9, =     

                    if (!Shift || !CAPSLOCK) //Layer One, v   
                    {
                        deSelectLetter();
                        currentLetterSelected += "v";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, V  
                    {
                        deSelectLetter();
                        currentLetterSelected += "V";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 9 
                    {
                        deSelectLetter();
                        currentLetterSelected += "9";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, =  
                    {
                        deSelectLetter();
                        currentLetterSelected += "=";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 276.923077f && Rangle > 249.2307693f: // Layers: w, W, 0, /      

                    if (!Shift || !CAPSLOCK) //Layer One, w   
                    {
                        deSelectLetter();
                        currentLetterSelected += "w";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, W  
                    {
                        deSelectLetter();
                        currentLetterSelected += "W";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, 0 
                    {
                        deSelectLetter();
                        currentLetterSelected += "0";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, /  
                    {
                        deSelectLetter();
                        currentLetterSelected += "/";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 304.6153847f && Rangle > 276.923077f: // Layers: x, X, ., *       

                    if (!Shift || !CAPSLOCK) //Layer One, x   
                    {
                        deSelectLetter();
                        currentLetterSelected += "x";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, X  
                    {
                        deSelectLetter();
                        currentLetterSelected += "X";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, .  
                    {
                        deSelectLetter();
                        currentLetterSelected += ".";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, *  
                    {
                        deSelectLetter();
                        currentLetterSelected += "*";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 332.3076924f && Rangle > 304.6153847f: // Layers: y, Y, ,, -       

                    if (!Shift || !CAPSLOCK) //Layer One, y   
                    {
                        deSelectLetter();
                        currentLetterSelected += "y";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Y  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Y";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, ,  
                    {
                        deSelectLetter();
                        currentLetterSelected += ",";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, -  
                    {
                        deSelectLetter();
                        currentLetterSelected += "-";
                        isCenter = false;
                    }
                    break;

                case float Rangle when Rangle <= 360f && Rangle > 332.3076924f: // Layers: z, Z, $, +       

                    if (!Shift || !CAPSLOCK) //Layer One, z   
                    {
                        deSelectLetter();
                        currentLetterSelected += "z";
                        isCenter = false;
                    }

                    if (Shift || CAPSLOCK) //Layer Two, Z  
                    {
                        deSelectLetter();
                        currentLetterSelected += "Z";
                        isCenter = false;
                        ShiftStage = 2f;
                    }

                    if (Numbers) //Layer Three, $   
                    {
                        deSelectLetter();
                        currentLetterSelected += "$";
                        isCenter = false;
                    }

                    if (SpecialCharacters) //Layer Four, +   
                    {
                        deSelectLetter();
                        currentLetterSelected += "+";
                        isCenter = false;
                    }
                    break;

                default:
                    print("Character Not On Pallet");
                    break;
            }
        }
    }

    //I could have done this whole thing better because I'm going to have to check for true/false later on when I could have done it in one. For now its a POC. 
    public void buttonSelect()
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

        //1f act1vated number5  
        if (Numbers)
        {
            NumbersText.text = "Numb: On";
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
            NumbersText.text = "Numb: Off"; 

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

        //!f speci@! ch@r@cters @re ()n
        if (SpecialCharacters)
        {
            Numbers = false;
            SpecialCharactersText.text = "Char: On";

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
            SpecialCharactersText.text = "Charr: Off";

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

        //First check to see if PrimaryThumb is centered 
        if (Langle == 0f && Rangle == 0f)
        {
            isCenter = true;
            print("String: " + currentLetterSelected.Length + ", Float: " + letterStringLength);
            letterStringLength = currentLetterSelected.Length;

            if (ShiftStage == 2f)
            {
                Shift = false;
                ShiftStage = 0f;
            }
        }
    }
        



    void Update()
    {
        Langle = axis.Langle;
        Rangle = axis.Rangle; 
        letterSelect();
        buttonSelect();

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
        //if (Input.GetKeyDown("q") && isCenter)
        //{
        //    deleteLetter();
        //}

        //if (Input.GetKeyDown("s") && isCenter)
        //{
        //    space();
        //}

        //if (isCenter == true)
        //{
        //    //currentLetterSelected += letterOutput;
        //    if (letterOutput != currentLetterSelected)
        //    {
        //        //print("Astra: " + astra);
        //        letterOutput = currentLetterSelected;
        //    }
        //}

        //OVR.text = "CAPS: " + OVRInput.Get(OVRInput.Button.PrimaryThumbstick);
        //isCenterText.text = "isCenter: " + isCenter;
        //lOutput.text = "Curr: " + currentLetterSelected;
        //output.text = "Output: " + letterOutput;

        output.text = "Output: " + currentLetterSelected;
        //soOn.text = "CAPS: " + CAPSLOCK; 

    }
}
