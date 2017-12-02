using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour {

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        DAMAGECALC,
        LOSE,
        WIN
    }

    private BattleStates currentState;

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
                break;
            case (BattleStates.PLAYERCHOICE):
                //StartCoroutine("PlayerTurn");  // follow tutorial online to figure out why doesn't work
                PlayerTurn();
                break;
            case (BattleStates.ENEMYCHOICE):
                StartCoroutine("EnemyTurn");
                break;
            case (BattleStates.DAMAGECALC):
                DamageCalculation();
                break;
            case (BattleStates.LOSE):
                break;
            case (BattleStates.WIN):
                break;
        }
        //if (playersTurn && playerChoose == -1) return;
        ////player hasn't chosen and is his/her turn
        ////chose rock / paper / scissors
        ////fill bar phase
        //StartCoroutine("PlayerTurn");
        ////StartCoroutine("Wait");
        ////bot turn
        //// damage phase
        ////checkwinner();

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
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3);
        BotChoose();
        printChoice(); // prints crazy amount
        currentState = BattleStates.DAMAGECALC;

    }

    IEnumerator DamageCalculation()
    {
        yield return new WaitForSeconds(3);
        currentState = BattleStates.WIN;
        // currentState = BattleStates.LOSE;
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
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Stab) // rock vs paper
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nBOT wins";
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Flip) // scissors vs rock
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose FLIP\nBOT wins";
        }
        else if (playerChoose == (int)elements.Flip && botChoose == (int)elements.Pinch) // rock vs scissors
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nPLAYER wins";
        }
        else if (playerChoose == (int)elements.Stab && botChoose == (int)elements.Pinch) // paper vs scissors
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "BOT chose PINCH\nBOT wins";
        }
        else if (playerChoose == (int)elements.Pinch && botChoose == (int)elements.Stab) // scissors vs paper
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "BOT chose STAB\nPLAYER wins";
        }
    }

    public void PlayerChoose(int choose)
    {
    currentState = BattleStates.PLAYERCHOICE;
    playerChoose = choose;
    }

    public void playerSlider()
    {
        fill_value = fillBarManager.fill_value;

    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 4);
       
    }
}
