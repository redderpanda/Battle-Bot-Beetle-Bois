using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour {

    [SerializeField]
    private Text myText;
    [SerializeField]
    private MissionListManager missionManager;

    private string myTextString;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void OnClick()
    {
        missionManager.MissionClicked(myTextString);
    }

}
