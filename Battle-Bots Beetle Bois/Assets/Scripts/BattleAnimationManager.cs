using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAnimationManager : MonoBehaviour {


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

        beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.mySprite;
        beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.wings.myIcon.sprite;
        beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.legs.myIcon.sprite;
        beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.arms.myIcon.sprite;

        e_beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.mySprite;
        e_beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.wings.myIcon.sprite;
        e_beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.legs.myIcon.sprite;
        e_beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.arms.myIcon.sprite;

    }
	

    public void switchBeetle()
    {
        beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.mySprite;
        beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.wings.myIcon.sprite;
        beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.legs.myIcon.sprite;
        beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.current_beetleboi.arms.myIcon.sprite;

    }

    public void e_switchBeetle()
    {
        e_beetleboi_sprite.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.mySprite;
        e_beetle_boi_wings.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.wings.myIcon.sprite;
        e_beetle_boi_legs.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.legs.myIcon.sprite;
        e_beetle_boi_arms.GetComponent<Image>().sprite = healthBarManager.e_current_beetleboi.arms.myIcon.sprite;

    }

    public IEnumerator flash()
    {

        beetleboi_sprite.enabled = false;
        beetle_boi_wings.enabled = false;
        beetle_boi_legs.enabled = false;
        beetle_boi_arms.enabled = false;

        yield return new WaitForSeconds(0.1f);

        beetleboi_sprite.enabled = true;
        beetle_boi_wings.enabled = true;
        beetle_boi_legs.enabled = true;
        beetle_boi_arms.enabled = true;

    }

    public IEnumerator e_flash()
    {

        e_beetleboi_sprite.enabled = false;
        e_beetle_boi_wings.enabled = false;
        e_beetle_boi_legs.enabled = false;
        e_beetle_boi_arms.enabled = false;

        yield return new WaitForSeconds(0.1f);

        e_beetleboi_sprite.enabled = true;
        e_beetle_boi_wings.enabled = true;
        e_beetle_boi_legs.enabled = true;
        e_beetle_boi_arms.enabled = true;

    }
}
