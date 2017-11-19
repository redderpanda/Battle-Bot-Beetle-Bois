using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BBBBWings : MonoBehaviour {

    [SerializeField]
    private Image myIcon;

    public string wing_name;
    public int health = 0;
    public int defense = 0;
    public int pinch_stat = 0;
    public int lift_stat = 0;
    public int stab_stat = 0;

    public void SetIcon(Sprite mySprite)
    {
        myIcon.sprite = mySprite;
    }
}
