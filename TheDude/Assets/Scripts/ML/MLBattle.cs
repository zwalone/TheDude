using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLBattle : MonoBehaviour
{
    public Entity agent;
    public Entity enemy;

    public delegate void AfterEffects();
    public AfterEffects afterEffects;
    public int turn;
    public bool battleFinished;
    private void Start()
    {
        SetupBattle();
    }
    private void Update()
    {
       if(!battleFinished) NextTurn();
    }
    public void SetupBattle()
    {
        turn = 0;
        agent.Opponent = enemy;
        enemy.Opponent = agent;
        battleFinished = false;
    }
    void NextTurn()
    {
        if (!EveryoneAlive()) return;

        Debug.Log($"{agent.Stats.CharName} : {agent.Stats.Hp} --- {enemy.Stats.CharName} : {enemy.Stats.Hp}");
        //turn++;
        //if (afterEffects != null)
        //    afterEffects();

        if (CompareDex(agent, enemy))
        {
            Turn(agent); Turn(enemy);
        }
        else
        {
            Turn(enemy); Turn(agent);
        }
 
    }

    public void Turn(Entity entity)
    {
        entity.MakeAction();
    }
    bool EveryoneAlive() 
    {
        if (agent.Stats.IsAlive() && enemy.Stats.IsAlive()) return true;
        else
        {
            battleFinished = true;
            EndBattle();
            return false;
        } 
    
    }
    void EndBattle()
    {
        if (agent.Stats.IsAlive()) Debug.Log("Agent Wygral");
        else Debug.Log("Agent Przegral");
    }
    public bool CompareDex(Entity first, Entity second)
    {
        if (first.Stats.Dex.Val >= second.Stats.Dex.Val) return false;
        else return true;
    }
}
