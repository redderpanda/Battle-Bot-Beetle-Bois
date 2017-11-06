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

   public void FillBarPhase()
    {
        GameObject S = Instantiate(SliderPrefab) as GameObject;
        S.transform.SetParent(canvas.transform,false);
        
        GameObject slider_button = Instantiate(SliderButtonPrefab) as GameObject;
        slider_button.transform.SetParent(canvas.transform,false);

        GameObject slider_button_manager = Instantiate(SliderButtonManagerPrefab) as GameObject;
        slider_button_manager.transform.SetParent(canvas.transform,false);

        GameObject slider_manager = Instantiate(SliderManagerPrefab) as GameObject;
        slider_manager.transform.SetParent(canvas.transform,false);

        ScreenManager screen_manager_script = slider_button_manager.GetComponent<ScreenManager>(); // cant set object in script due to instantiating GameObjects vs ScreenManagers
        //screen_manager_script.slider_m = slider_manager;



    }
}
