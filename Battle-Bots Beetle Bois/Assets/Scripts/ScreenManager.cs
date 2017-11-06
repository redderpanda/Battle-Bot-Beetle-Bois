using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour {

    public SliderManager slider_m;
	public void screenTouch () {

        slider_m.shouldFill = false;

    }
}
