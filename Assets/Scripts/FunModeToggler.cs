using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FunModeToggler : MonoBehaviour
{
    public TMP_Text ButtonTextMode;
    public TMP_Text ButtonDisclaimer;
    public TMP_Text BigScreenTextMode;

    public void Start() 
    {
        
    }

    public void Toggle()
    {
        if (PlayerPrefs.GetInt("FunMode") == 1) 
            {
                ButtonTextMode.text = "Change to Fun Mode";
                ButtonDisclaimer.text = "Fun Mode has A LOT of flashing colors and can be very straining to the eye";
                BigScreenTextMode.text = "(Boring Mode)";
                PlayerPrefs.SetInt("FunMode", 0);
        } else
        {
                ButtonTextMode.text = "Change to Boring Mode";
                ButtonDisclaimer.text = "Boring Mode is like Fun Mode but boring";
                BigScreenTextMode.text = "(FUN MODE!!!!)";
                PlayerPrefs.SetInt("FunMode", 1);
        }        
    }
}
