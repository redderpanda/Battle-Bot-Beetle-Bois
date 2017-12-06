using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSystemManager : MonoBehaviour {

    public HealthBarManager healthManager;
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        CALCULATION,
        LOSE,
        WIN,
        DRAW,
        END
    }

    public BattleStates currentState;

    enum elements { Pinch = 1, Stab = 2, Flip = 3 }

    public int playerChoose = -1;

    public int botChoose = -1;
    public int botSlider = -1;

    public Text WinnerText;
    public Text SliderText;
    public Text DamageText;
    public FillBarManager fillBarManager;

    public float fill_value = 0;

    public bool coroutineStarted = false;

    void Start()
    {
        currentState = BattleStates.START;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (BattleStates.START):
                //battleStateStartScript.PrepareBattle();
                break;
            case (BattleStates.PLAYERCHOICE):
                break;
            case (BattleStates.ENEMYCHOICE):
                //StartCoroutine("EnemyTurn"); //ai code
                //BotChoose();
                BotChoose();
                break;
            case (BattleStates.CALCULATION):
                if (!coroutineStarted)
                {
                    StartCoroutine(WaitForSlider());
                }
                break;
            case (BattleStates.LOSE):
                DamageCalcLose();
                // do damage to player with multiplier from slider
                break;
            case (BattleStates.WIN):
                DamageCalcWin();
                // do damage to enemy with multiplier from slider
                break;
            case (BattleStates.DRAW):
                DamageCalcDraw();
                // check slider to see who's closer then apply damage
                break;
            case (BattleStates.END):
                WinnerText.GetComponent<Text>().text = "GAME OVER";
                SceneManager.LoadScene("Inventory");
                break; // end the map
        }


    }



    public void PlayerTurn()
    {
        fillBarManager.FillBarPhase();
        currentState = BattleStates.ENEMYCHOICE;
    }

    void DamageCalcWin()
    {
        double multiplier = 1;
        int attack_stat = 1; // to choose which stat to use for attack

        if (playerChoose == (int)elements.Flip)
            attack_stat = healthManager.current_beetleboi.liftCumulative();
        else if (playerChoose == (int)elements.Pinch)
            attack_stat = healthManager.current_beetleboi.pinchCumulative();
        else if (playerChoose == (int)elements.Stab)
            attack_stat = healthManager.current_beetleboi.stabCumulative();

        float e_closeness = Mathf.Abs(((float)fillBarManager.sweet_spot - (float)botSlider));  // decide multiplier for damage
        float closeness = Mathf.Abs(((float)fillBarManager.sweet_spot - fill_value));

        if (closeness < e_closeness)
            multiplier = 2;
        else if (closeness > e_closeness)
            multiplier = .5;

        SliderText.GetComponent<Text>().text = closeness + " vs " + e_closeness;
        DamageText.GetComponent<Text>().text = (attack_stat - healthManager.e_current_beetleboi.defense) + " DAMAGE x " + multiplier;
        healthManager.e_current_health = healthManager.e_current_health - (int)((attack_stat - healthManager.e_current_beetleboi.defense) * multiplier); // deal damage to enemy
        fill_value = 0;
        currentState = BattleStates.PLAYERCHOICE;
    }

    void DamageCalcLose()
    {
        double multiplier = 1;
        int attack_stat = 1; // to choose which stat to use for attack

        if (botChoose == (int)elements.Flip)
            attack_stat = healthManager.e_current_beetleboi.liftCumulative();
        else if (botChoose == (int)elements.Pinch)
            attack_stat = healthManager.e_current_beetleboi.pinchCumulative();
        else if (botChoose == (int)elements.Stab)
            attack_stat = healthManager.e_current_beetleboi.stabCumulative();

        float e_closeness = Mathf.Abs((fillBarManager.sweet_spot - (float)botSlider)); // decide multiplier for damage by closeness
        float closeness = Mathf.Abs(((float)fillBarManager.sweet_spot - fill_value));

        if (closeness > e_closeness)
            multiplier = 2;
        else if (closeness < e_closeness)
            multiplier = .5;

        SliderText.GetComponent<Text>().text = closeness + " vs " + e_closeness;
        DamageText.GetComponent<Text>().text = (attack_stat - healthManager.current_beetleboi.defense) + " DAMAGE x " + multiplier;
        healthManager.current_health = healthManager.current_health - (int)((attack_stat - healthManager.current_beetleboi.defense) * multiplier); // deal damage to player
        fill_value = 0;
        currentState = BattleStates.PLAYERCHOICE;
    }


    void DamageCalcDraw()
    {
        float e_closeness = Mathf.Abs((fillBarManager.sweet_spot - (float)botSlider));
        float closeness = Mathf.Abs(((float)fillBarManager.sweet_spot - fill_value));

        int attack_stat = 1;

        SliderText.GetComponent<Text>().text = closeness + " vs " + e_closeness;
        if (closeness > e_closeness) // player is farther
        {
            if (playerChoose == (int)elements.Flip)
                attack_stat = healthManager.e_current_beetleboi.liftCumulative();
            if (playerChoose == (int)elements.Pinch)
                attack_stat = healthManager.e_current_beetleboi.pinchCumulative();
            else
            {
                attack_stat = healthManager.e_current_beetleboi.stabCumulative();
            }

            DamageText.GetComponent<Text>().text = (attack_stat - healthManager.current_beetleboi.defense) + " DAMAGE";
            healthManager.current_health = healthManager.current_health - (attack_stat - healthManager.current_beetleboi.defense); // deal damage to player
        }

        else // player is closer
        {
            if (playerChoose == (int)elements.Flip)
                attack_stat = healthManager.current_beetleboi.liftCumulative();
            if (playerChoose == (int)elements.Pinch)
                attack_stat = healthManager.current_beetleboi.pinchCumulative();
            else
            {
                attack_stat = healthManager.current_beetleboi.stabCumulative();
            }
            DamageText.GetComponent<Text>().text = (attack_stat - healthManager.e_current_beetleboi.defense) + " DAMAGE";
            healthManager.e_current_health = healthManager.e_current_health - (attack_stat - healthManager.e_current_beetleboi.defense); // deal damage to enemy
        }
        fill_value = 0;

        currentState = BattleStates.PLAYERCHOICE;
    }


        


    void printChoice() // delete later for deal damage
    {
        if (playerChoose == botChoose)
        {
            //draw
            WinnerText.GetComponent<Text>().text = "DRAW";
            coroutineStarted = false;
            currentState = BattleStates.DRAW;
        }
        else if (playerChoose == (int)elements.Stab && botChoose == (int)elements.Flip) // stab vs flip
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose FLIP\nBOT wins";
            coroutineStarted = false;
            currentState = BattleStates.LOSE;
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Stab) // flip vs stab
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nPLAYER wins";
            coroutineStarted = false;
            currentState = BattleStates.WIN;
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Flip) // pinch vs flip
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose FLIP\nPLAYER wins";
            coroutineStarted = false;
            currentState = BattleStates.WIN;
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Pinch) // flip vs pinch
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nBOT wins";
            coroutineStarted = false;
            currentState = BattleStates.LOSE;
        }
        else if (playerChoose == (int)elements.Stab && botChoose == (int)elements.Pinch) // stav vs pinch
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nPLAYER wins";
            coroutineStarted = false;
            currentState = BattleStates.WIN;
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Stab) // pinch vs stab
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nBOT wins";
            coroutineStarted = false;
            currentState = BattleStates.LOSE;
        }
    }

    public void PlayerChoose(int choose)
    {
        playerChoose = choose;
        fillBarManager.FillBarPhase();
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void playerSlider()
    {
        fill_value = fillBarManager.prev_fill_value;

    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 4); // ai randomly chooses
        botSlider = Random.Range((fillBarManager.sweet_spot - 10), (fillBarManager.sweet_spot + 10)); // ai gets in between 10 below and 10 above of the sweet spot
        currentState = BattleStates.CALCULATION;


    }
    IEnumerator WaitForSlider()
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(3);
        playerSlider();
        printChoice();
    }
    // *** REMIND CHRISTOPHE TO BUY APPLE CIDER VINEGAR ***
}
