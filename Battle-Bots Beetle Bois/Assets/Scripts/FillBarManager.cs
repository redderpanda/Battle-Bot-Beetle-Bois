using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarManager : MonoBehaviour {
    public GameObject SliderPrefab;
    public GameObject SliderButtonPrefab;
    public GameObject SliderButtonManagerPrefab;
    public GameObject SliderManagerPrefab;
    public GameObject canvas;
    int slider_value;

    public GameObject Slider;
    public GameObject SliderButton;
    public GameObject[] rpsButtons;    // Debug.Log("Test");


    public Slider fill_bar;
    public bool shouldFill = true;
    void Awake()
    {
        shouldFill = true;
        //  fill_bar.value = 0;
        Debug.Log(" the Fill Bar is  " + fill_bar.value);
    }
    void Start()
    {
        //   GameObject Slider = GameObject.FindGameObjectWithTag("Slider");
        Debug.Log("Hello");
        //  GameObject SliderButton = GameObject.FindGameObjectWithTag("Slider Button");
        // GameObject[] rpsButtons = GameObject.FindGameObjectsWithTag("RPS Button");
    }

    public void FillBarPhase()
    {
        for (int i = 0; i < rpsButtons.Length; i++)
        {

            rpsButtons[i].SetActive(false);
        }
        Slider.SetActive(true);
        SliderButton.SetActive(true);
    }

    public void switchActive(bool sliderr,bool buttonss)
     {
        for (int i = 0; i < rpsButtons.Length; i++)
        {

            rpsButtons[i].SetActive(buttonss);
        }
        Slider.SetActive(sliderr);
        SliderButton.SetActive(sliderr);
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

