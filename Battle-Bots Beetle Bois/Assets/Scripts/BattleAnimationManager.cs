using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAnimationManager : MonoBehaviour {

    public BBBBBase[] player_team = new BBBBBase[3]; // player team
    public BBBBBase[] enemy_team = new BBBBBase[3]; // enemy team

    public HealthBarManager healthBarManager;
    public Image beetleboi_sprite;
    public Image e_beetleboi_sprite;

    // Use this for initialization
    void Start () {
        beetleboi_sprite.enabled = true;
        e_beetleboi_sprite.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.myIcon.sprite;
        e_beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.myIcon.sprite;
    }
}
