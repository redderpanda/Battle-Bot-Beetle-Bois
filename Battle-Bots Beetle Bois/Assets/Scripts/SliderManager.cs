using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider fill_bar;
    public bool shouldFill = true;
    void Awake()
    {
        shouldFill = true;
    }


    void Update()
    {
        Debug.Log(shouldFill);
        if (shouldFill)
        {
            fill_bar.value++;
            Debug.Log("Fill bar = " + fill_bar.value);
        }

    }

}
