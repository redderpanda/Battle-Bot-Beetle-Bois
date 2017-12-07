using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAnimationManager : MonoBehaviour {

    public BBBBBase[] player_team = new BBBBBase[3]; // player team
    public BBBBBase[] enemy_team = new BBBBBase[3]; // enemy team

    public HealthBarManager healthBarManager;

    public Image beetleboi_sprite;
    public Image beetle_boi_wings;
    public Image beetle_boi_legs;
    public Image beetle_boi_arms;

    public Image e_beetleboi_sprite;
    public Image e_beetle_boi_wings;
    public Image e_beetle_boi_legs;
    public Image e_beetle_boi_arms;

    // Use this for initialization
    void Start () {
        beetleboi_sprite.enabled = true;
        beetle_boi_wings.enabled = true;
        beetle_boi_legs.enabled = true;
        beetle_boi_arms.enabled = true;

        e_beetleboi_sprite.enabled = true;
        e_beetle_boi_wings.enabled = true;
        e_beetle_boi_legs.enabled = true;
        e_beetle_boi_arms.enabled = true;


    }
	
	// Update is called once per frame
	void Update () {
        beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.mySprite;
        beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.wings.myIcon.sprite;
        beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.legs.myIcon.sprite;
        beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.arms.myIcon.sprite;

        e_beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.mySprite;
        e_beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.wings.myIcon.sprite;
        e_beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.legs.myIcon.sprite;
        e_beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.arms.myIcon.sprite;
    }
}
