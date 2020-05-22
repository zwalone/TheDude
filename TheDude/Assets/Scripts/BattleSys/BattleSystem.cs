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
    public delegate void AfterEffects();
    public AfterEffects afterEffects;
    public BattleState state;
    public Player player;
    public Enemy enemy;
    public GameObject enemyGO;
    public BattleHUD HUD;
    public BattleGUI GUI;
    public int turn;
    private bool whoFirst;
    public Entity ActiveEntity;

    private void Start() 
    {
        //if(GameManager.Instance.nextEnemy != null)
        // StartCoroutine(SetupBattle(GameManager.Instance.nextEnemy));
        if (GameManager.Instance.nextEnemy != null)
        {
            state = BattleState.START;
            enemyGO = (GameObject)Instantiate(GameManager.Instance.nextEnemy);
            enemy = enemyGO.GetComponent<Enemy>();
            DialogueManager.Instance.StartDialogue(enemy.dialogue);
        }
            
    }

    
    public IEnumerator SetupBattle()
    {
        turn = 0;
        HUD.SetHUD();
        GUI.SetInfo("The Battle Has Begun");
        GUI.SetInfo("Jazda");
        yield return new WaitForSeconds(2f);

        if(player.Stats.Dex.Val > enemy.Stats.Dex.Val)
            whoFirst = true;
        else 
            whoFirst = false;

        NextTurn();
    }

    void NextTurn()
    {
        turn++;
        GUI.SetInfo("Turn #" + turn);
        if(afterEffects != null)
		    afterEffects();
        player.Stats.ResetAC();
        HUD.UpdateHUD();
        IsDead();

        if (whoFirst)
        {
            ActiveEntity = player;
            state = BattleState.PLAYERTURN;
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    public void NextStage()
    {
        if(!IsDead())
        {
            if(state == BattleState.PLAYERTURN && whoFirst)
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            else NextTurn();
        }
    }

     public IEnumerator PlayerAction(int act)
    {
       //if(player.Stats.CastSkill(player.Skills[act].cost))
       if(true)
       {
            //player.Skills[act].Activate();
            HUD.UpdateHUD();
            yield return new WaitForSeconds(2f);
       }
    }

    IEnumerator EnemyTurn()
    {
        ActiveEntity = enemy;
        yield return new WaitForSeconds(1f);
        GUI.SetInfo("Enemy Attack !");
        player.Stats.TakeDamage(-10);
        HUD.UpdateHUD();
        yield return new WaitForSeconds(1f);

        if (whoFirst)
            NextTurn();
        else
        {
            ActiveEntity = player;
            state = BattleState.PLAYERTURN;
        }
            
        
    }

   void EndBattle()
	{
		if(state == BattleState.WON)
		{
            GUI.SetInfo("You won the battle!");
		} 
        else if (state == BattleState.LOST)
		{
            GUI.SetInfo("You were defeated.");
		}
        Destroy(enemyGO);
	}

    public void MakeChoice(int num)
    {
        if(state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAction(num));
    }

    bool IsDead()
    {
        if(!enemy.Stats.IsAlive())
		{
            state = BattleState.WON;
			EndBattle();
            return true;
		}
        else if(!player.Stats.IsAlive())
		{
            state = BattleState.LOST;
			EndBattle();	
            return true;
		}
        else return false;

    }
}
