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
      //  fill_bar.value = 0;
        Debug.Log(" the Fill Bar is  " + fill_bar.value);
    }


    void Update()
    {
        if (shouldFill)
        {
            fill_bar.value++; 
        }
    }

}
