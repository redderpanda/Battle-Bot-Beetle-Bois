using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour {

    private BattleStateStart battleStateStartScript = new BattleStateStart();
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        LOSE,
        WIN,
        DRAW,
        END
    }

    public BattleStates currentState;

    enum elements { Pinch = 1, Stab, Flip }

    public int playerChoose = -1;
    public int botChoose = -1;

    public Text WinnerText;
    public FillBarManager fillBarManager;

    public float fill_value;

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
                battleStateStartScript.PrepareBattle();
                break;
            case (BattleStates.PLAYERCHOICE):
                //StartCoroutine("PlayerTurn");  // follow tutorial online to figure out why doesn't work
                //PlayerTurn();
                break;
            case (BattleStates.ENEMYCHOICE):
                //StartCoroutine("EnemyTurn"); //ai code
                BotChoose();
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
                break; // end the map
        }


    }

    //IEnumerator PlayerTurn()
    //{
    //    fillBarManager.FillBarPhase();
    //    yield return new WaitForSeconds(3);
    //    currentState = BattleStates.ENEMYCHOICE;
    //}

    public void PlayerTurn()
    {
        fillBarManager.FillBarPhase();
        currentState = BattleStates.ENEMYCHOICE;
    }

    void DamageCalcWin()  ////// ****LOOK HERE THIS WHERE YOU LEFT **** 
    {
        Debug.Log("DAMAGE CALCULATION WINNER");
        currentState = BattleStates.PLAYERCHOICE;
    }
    void DamageCalcLose()
    {
        Debug.Log("DAMAGE CALCULATION LOSER");
        currentState = BattleStates.PLAYERCHOICE;
    }
    void DamageCalcDraw()
    {
        Debug.Log("DAMAGE CALCULATION TIE");
        currentState = BattleStates.PLAYERCHOICE;
    }


        


    void printChoice() // delete later for deal damage
    {
        if (playerChoose == botChoose)
        {
            //draw
            WinnerText.GetComponent<Text>().text = "DRAW";
        }
        else if (playerChoose == (int)elements.Stab && botChoose == (int)elements.Flip) // paper vs rock
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose FLIP\nPLAYER wins";
            currentState = BattleStates.WIN;
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Stab) // rock vs paper
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nBOT wins";
            currentState = BattleStates.LOSE;
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Flip) // scissors vs rock
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose FLIP\nBOT wins";
            currentState = BattleStates.LOSE;
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Pinch) // rock vs scissors
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nPLAYER wins";
            currentState = BattleStates.WIN;
        }
        else if (playerChoose == (int)elements.Stab && botChoose == (int)elements.Pinch) // paper vs scissors
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nBOT wins";
            currentState = BattleStates.LOSE;
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Stab) // scissors vs paper
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nPLAYER wins";
            currentState = BattleStates.WIN;
        }
    }

    public void PlayerChoose(int choose)
    {
        currentState = BattleStates.PLAYERCHOICE;
        playerChoose = choose;
        fillBarManager.FillBarPhase(); // maybe make thiss an enum
        currentState = BattleStates.ENEMYCHOICE;
    }

    public void playerSlider()
    {
        fill_value = fillBarManager.fill_value;

    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 4);
        //currentState = BattleStates.DAMAGECALC;
        printChoice();
    }
}
