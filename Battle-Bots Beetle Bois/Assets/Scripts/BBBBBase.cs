using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BBBBBase : MonoBehaviour {

    [SerializeField]
    public Image myIcon;
    public Sprite mySprite;

    public string beetle_name;
    public int health = 0;
    public int defense = 0;
    public int pinch_stat = 0;
    public int lift_stat = 0;
    public int stab_stat = 0;

    public BBBBArms arms;
    public BBBBLegs legs;
    public BBBBWings wings;

    //public BBBBPart testarms;


    public void SetIcon(Sprite mySprite)
    {
        myIcon.sprite = mySprite;
    }

    public int healthCumulative()
    {
        int new_health = health;
        new_health += arms.GetComponent<BBBBArms>().health 
            + legs.GetComponent<BBBBLegs>().health 
            + wings.GetComponent<BBBBWings>().health;
        return new_health;
    }

    public int defenseCumulative()
    {
        int new_defense = defense;
        new_defense += arms.GetComponent<BBBBArms>().defense
            + legs.GetComponent<BBBBLegs>().defense
            + wings.GetComponent<BBBBWings>().defense;
        return new_defense;
    }

    public int pinchCumulative()
    {
        int new_pinch = pinch_stat;
        new_pinch += arms.GetComponent<BBBBArms>().pinch_stat
            + legs.GetComponent<BBBBLegs>().pinch_stat
            + wings.GetComponent<BBBBWings>().pinch_stat;
        return new_pinch;
    }

    public int liftCumulative()
    {
        int new_lift = lift_stat;
        new_lift += arms.GetComponent<BBBBArms>().lift_stat
            + legs.GetComponent<BBBBLegs>().lift_stat
            + wings.GetComponent<BBBBWings>().lift_stat;
        return new_lift;
    }

    public int stabCumulative()
    {
        int new_stab = stab_stat;
        new_stab += arms.GetComponent<BBBBArms>().stab_stat
            + legs.GetComponent<BBBBLegs>().stab_stat
            + wings.GetComponent<BBBBWings>().stab_stat;
        return new_stab;
    }
}


