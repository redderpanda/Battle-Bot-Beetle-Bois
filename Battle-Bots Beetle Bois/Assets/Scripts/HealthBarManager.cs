using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {

    public BattleSystemManager battleManager;
    public BattleAnimationManager animationManager;

    public BBBBBase [] player_team = new BBBBBase [3]; // player team
    public BBBBBase [] enemy_team = new BBBBBase [3]; // enemy team

    private int player_c_health_0;
    private int player_c_health_1;
    private int player_c_health_2;

    private int enemy_c_health_0;
    private int enemy_c_health_1;
    private int enemy_c_health_2;

    public Button[] player_buttons = new Button[3];
    public Button[] enemy_buttons = new Button[3];

    public int[] player_c_health = new int [3];
    public int[] enemy_c_health = new int [3];

    public Slider health_bar;  // health bar
    public Text health_bar_text;
    public BBBBBase current_beetleboi;
    public int current_health;

    public Slider e_health_bar;  // enemy health bar
    public Text e_health_bar_text;
    public BBBBBase e_current_beetleboi;
    public int e_current_health;


    void Start()
    {
        // Player and Enemy initialization
        player_c_health_0 = player_team[0].healthCumulative();
        player_c_health[0] = player_c_health_0;
        player_c_health_1 = player_team[1].healthCumulative();
        player_c_health[1] = player_c_health_1;
        player_c_health_2 = player_team[2].healthCumulative();
        player_c_health[2] = player_c_health_2;

        enemy_c_health_0 = enemy_team[0].healthCumulative();
        enemy_c_health[0] = enemy_c_health_0;
        enemy_c_health_1 = enemy_team[1].healthCumulative();
        enemy_c_health[1] = enemy_c_health_1;
        enemy_c_health_2 = enemy_team[2].healthCumulative();
        enemy_c_health[2] = enemy_c_health_2;

        // Player and Enemy team setting
        current_beetleboi = player_team[0];
        health_bar.maxValue = player_c_health_0;
        current_health = player_c_health_0;

        e_current_beetleboi = enemy_team[0];
        e_health_bar.maxValue = enemy_c_health_0;
        e_current_health = enemy_c_health_0;

        // Playre and Enemy button setting
        player_buttons[0].GetComponent<Image>().sprite = player_team[0].myIcon.sprite;
        player_buttons[1].GetComponent<Image>().sprite = player_team[1].myIcon.sprite;
        player_buttons[2].GetComponent<Image>().sprite = player_team[2].myIcon.sprite;

        enemy_buttons[0].GetComponent<Image>().sprite = enemy_team[0].myIcon.sprite;
        enemy_buttons[1].GetComponent<Image>().sprite = enemy_team[1].myIcon.sprite;
        enemy_buttons[2].GetComponent<Image>().sprite = enemy_team[2].myIcon.sprite;
    }
	// Update is called once per frame
	void Update () {
        faintedBeetle();
        faintedEnemyBeetle();
        current_health = lowerThanZero(current_health);
        health_bar.value = current_health;
        health_bar_text.text = current_beetleboi.beetle_name   +  "\nHEALTH: " + current_health + "/" + current_beetleboi.healthCumulative();

        e_current_health = lowerThanZero(e_current_health);
        e_health_bar.value = e_current_health;
        e_health_bar_text.text = e_current_beetleboi.beetle_name +  "\nHEALTH: " + e_current_health + "/" + e_current_beetleboi.healthCumulative();

        //endBattle();
    }

    int lowerThanZero(int health)
    {
        if(health <= 0)
        {
            return 0;
        }
        return health;
    }

    void faintedBeetle() // if current beetle is fainted switch out, if they're all fainted then end
    {
        if (current_health == 0)
        {

            int next = nextBeetle(player_c_health);

            if (next != -1) // there exists a non-fainted beetle
            {
                switchBeetle(next);
            }
            else // game over
            {
                endBattle();
            }
        }
    }
    void faintedEnemyBeetle() // if enemy current beeetle is fainted switch out, if they're all fainted then end
    {
        if (e_current_health == 0)
        {
            int next = nextBeetle(enemy_c_health);
            if(next != -1)
            {
                switchEnemyBeetle(next);
            }
            else
            {
                endBattle();
            }
        }
    }


    int nextBeetle(int[] health_array) // return next beetle index that isn't fainted.  If it fails it returns -1
    {
        for(int i = 0; i < 3; i++)
        {
            if (health_array[i] > 0)
            {
                return i;
            }
        }
        return -1;
    }

    void endBattle()
    {
        if (e_current_health <= 0 || current_health <= 0)
            battleManager.currentState = BattleSystemManager.BattleStates.END;
    }

    public void switchBeetle(int index) // attached to a button to execute beetle switching
    {
        int old_index = System.Array.IndexOf(player_team, current_beetleboi);

        player_c_health[old_index] = current_health;
        if (current_health == 0)
        {
            player_buttons[old_index].interactable = false;
        }

        current_beetleboi = player_team[index];
        health_bar.maxValue = current_beetleboi.healthCumulative();

        current_health = player_c_health[index];
        animationManager.switchBeetle();

    }

    void switchEnemyBeetle(int index) // set value for fainted beetle and set index beetle to be the current beetle
    {
        int old_index = System.Array.IndexOf(enemy_team, e_current_beetleboi);

        enemy_c_health[old_index] = e_current_health;
        if (e_current_health == 0)
        {
            enemy_buttons[old_index].interactable = false;
        }

        e_current_beetleboi = enemy_team[index];
        e_health_bar.maxValue = e_current_beetleboi.healthCumulative();

        e_current_health = enemy_c_health[index];
        animationManager.e_switchBeetle();
    }
}
