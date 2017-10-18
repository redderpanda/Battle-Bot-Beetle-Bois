using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour {

    public BattleBotBeetleBoi[] boiLibrary;
	// Use this for initialization
	void Start () {
        boiLibrary = new BattleBotBeetleBoi[20];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
        {
            Debug.Log("got touched");
        }
	}

}
