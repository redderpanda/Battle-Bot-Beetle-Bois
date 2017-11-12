using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarManager : MonoBehaviour {
   
    public GameObject canvas;
    int slider_value;

    public GameObject Slider;
    public GameObject SliderButton;
    public GameObject[] rpsButtons;    // Debug.Log("Test");


    public Slider fill_bar;
    public bool shouldFill = true;
 
   

    public void FillBarPhase()
    {
        for (int i = 0; i < rpsButtons.Length; i++)
        {

            rpsButtons[i].SetActive(false);
        }
        Slider.SetActive(true);
        SliderButton.SetActive(true);
        shouldFill = true;
    }
    public void screenTouch()
    {
        shouldFill = false;
    }
    void Update()
    {
        if (shouldFill)
        {
            fill_bar.value++;
        }
    }



}

