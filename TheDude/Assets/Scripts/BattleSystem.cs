using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSE }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject player;
    public GameObject enemy;
    

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        if(player.GetComponent<CharacterStats>().dex >= enemy.GetComponent<CharacterStats>().dex)
        {
            state = BattleState.PLAYERTURN;

        }
        else
        {
            state = BattleState.ENEMYTURN;
        }
    }
    
    private void PlayerTurn()
    {

    }

    private void EnemyTurn()
    {

    }

}
