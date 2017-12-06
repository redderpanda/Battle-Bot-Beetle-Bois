using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarManager : MonoBehaviour {
   
    public GameObject canvas;

    public GameObject Slider;
    public GameObject SliderButton;
    public GameObject[] rpsButtons;    // Debug.Log("Test");


    public Slider fill_bar;
    public bool shouldFill = true;
    public float prev_fill_value = 0;

    public int sweet_spot = 90;

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
    //public IEnumerator FillBarPhase()
    //{
    //    for (int i = 0; i < rpsButtons.Length; i++)
    //    {

    //        rpsButtons[i].SetActive(false);
    //    }
    //    Slider.SetActive(true);
    //    SliderButton.SetActive(true);
    //    shouldFill = true;
    //    yield return new WaitForSeconds(3);
    //    Slider.SetActive(false);
    //    SliderButton.SetActive(false);
    //    fill_bar.value = 0;
    //    for (int i = 0; i < rpsButtons.Length; i++)
    //    {

    //        rpsButtons[i].SetActive(true);
    //    }
    //}

    public void screenTouch()
    {   
        shouldFill = false;
        prev_fill_value = fill_bar.value;
        Slider.SetActive(false);
        SliderButton.SetActive(false);
        fill_bar.value = 0;
        for (int i = 0; i < rpsButtons.Length; i++)
        {
            rpsButtons[i].SetActive(true);
        }

    }

    void Update()
    {
        if (shouldFill)
        {
            fill_bar.value++;
        }

        if(fill_bar.value == 100)
        {
            screenTouch();
        }

    }


}

