using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem _instance;
    public static BattleSystem Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BattleSystem>();
            }

            return _instance;
        }
    }
    public BattleState state;
    public Transform plBatStation;
    public Transform enBatStation;

    public Player player;
    public Enemy enemy;
    public GameObject enemyGO;
    //public BattleHUD pHUD;
    //public BattleHUD eHUD;

    private void Start()
    {
        
        //pHUD.SetHUD(player.stats);
        //eHUD.SetHUD(enemy.stats);
        
        
    }

    public IEnumerator SetupBattle(GameObject en)
    {
        state = BattleState.START;
        enemyGO = Instantiate(en, enBatStation);
        enemy = en.GetComponent<Enemy>();
        enemy.GetComponent<CharacterStats>();
        enemy.stats.hp.value = 70;

        Debug.Log("Bitwa sie Zaczela");
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

     IEnumerator PlayerAction(int act)
    {
        bool isDead;
        player.ability[act].Use();
        yield return new WaitForSeconds(2f);

        if(enemy.stats.hp.value >0) isDead = false;
        else  isDead = true;
        

        if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
    }
    
    private void PlayerTurn()
    {
		//dialogueText.text = "Choose an action:";
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = player.stats.TakeDamage(-10);
        Debug.Log("Enemy Atakuje 10");
        yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

    }

    public void OnR1Buttom()
    {
        if(state != BattleState.PLAYERTURN)
           return;

        StartCoroutine(PlayerAction(0));
    }
    public void OnR2Buttom()
    {
        if(state != BattleState.PLAYERTURN)
           return;

        StartCoroutine(PlayerAction(1));
        
    }

    void EndBattle()
	{
		if(state == BattleState.WON)
		{
            Debug.Log("You won the battle!");
		} 
        else if (state == BattleState.LOST)
		{
			Debug.Log("You were defeated.");
		}
        Destroy(enemyGO);
	}

}
