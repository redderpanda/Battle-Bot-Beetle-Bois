using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart : MonoBehaviour {
    private BBBBBase newEnemy = new BBBBBase();
    private string[] enemyNames = new string[] { "BATTLE BOI 1", "BATTLE BOI 2", "BATTLE BOI 3" };

    public void PrepareBattle()
    {
        CreateNewEnemy();

    }

    private void CreateNewEnemy()
    {
        newEnemy.beetle_name = enemyNames[Random.Range(0,enemyNames.Length)];
        newEnemy.health = 200;
        newEnemy.defense = 100;
        newEnemy.pinch_stat = 20;
        newEnemy.stab_stat = 10;
        newEnemy.lift_stat = 30;
        // BattleSystemManager.currentState = BattleSystemManager.BattleStates.PLAYERCHOICE;
    }
}
