using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLBattle : MonoBehaviour
{
    public Agent agent;
    public Entity enemy;

    public MLBattleView view;
    public int turn;
    public bool battleFinished;
    public int BattleSpeed;

    int _slowBattle;
    private void Start()
    {
        SetupBattle();
    }
    private void Update()
    {
        if (!view.LogOpen() && !battleFinished)
        {
            if (_slowBattle == 0)
            {
                if (!battleFinished) NextTurn();
                _slowBattle = BattleSpeed;
            }
            else
                _slowBattle--;
        }
    }
    public void SetupBattle()
    {
        view.SetView(agent, enemy);
        turn = 0;
        agent.Opponent = enemy;
        enemy.Opponent = agent;
        battleFinished = false;
    }
    void NextTurn()
    {
        if (!EveryoneAlive()) return;

        view.log.NewTurn(turn);
        turn++;

        bool whofirst = CompareDex(agent, enemy);
        OrderOfTurn(whofirst);
        if(EveryoneAlive()) OrderOfTurn(!whofirst);

    }
    public void OrderOfTurn(bool whofirst)
    {
        if (whofirst) Turn(agent);
        else Turn(enemy);
    }

    public void Turn(Entity entity)
    {
        entity.Effects.ActivateFunctions();
        entity.UpdateCooldown();
        int chosenAction = entity.MakeAction(view.log);
        view.ActivateDiode(chosenAction);
    }
    bool EveryoneAlive() 
    {
        string stats = view.UpdateView();
        view.log.AddStats(stats);
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
        if (agent.Stats.IsAlive())
        {
            view.log.AddToLog("Agent Wygral");
            view.BattleWon();
        }
        else
        {
            view.log.AddToLog("Agent Przegral");
            view.BattleLost();
        } 
    }
    public bool CompareDex(Entity first, Entity second)
    {
        if (first.Stats.Dex >= second.Stats.Dex) return false;
        else return true;
    }
}
