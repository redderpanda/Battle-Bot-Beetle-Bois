using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {

    public Slider health_bar;
    public Text health_bar_text;
    public BBBBBase beetleboi;
    public int current_health;

    public Slider e_health_bar;
    public Text e_health_bar_text;
    public BBBBBase e_beetleboi;
    public int e_current_health;


    void Start()
    {
        int p_max = beetleboi.healthCumulative();
        health_bar.maxValue = p_max;
        current_health = p_max;

        int e_max = e_beetleboi.healthCumulative();
        e_health_bar.maxValue = e_max;
        e_current_health = e_max;
    }
	// Update is called once per frame
	void Update () {
        health_bar.value = current_health;
        health_bar_text.text = "HEALTH: " + current_health + "/" + beetleboi.healthCumulative();

        e_health_bar.value = e_current_health;
        e_health_bar_text.text = "HEALTH: " + e_current_health + "/" + e_beetleboi.healthCumulative();

        current_health--;
        e_current_health--;

    }
}
