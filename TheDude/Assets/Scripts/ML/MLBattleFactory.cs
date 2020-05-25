﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MLBattleFactory : MonoBehaviour
{
    public GameObject ViewPrefab;
    public GameObject BattlePrefab;
    public GameObject MainView;

    public Agent AgentPrefab;
    public Entity EnemyPrefab;

    public Transform ParentForBattles;
    public Transform ParentForViews;

    public MLBattle CreateBattle(int battleSpeed)
    {
        var battle = Instantiate(BattlePrefab);
        var view = Instantiate(ViewPrefab);
        battle.transform.SetParent(ParentForBattles);
        view.transform.SetParent(ParentForViews);

        MLBattle currentBattle = battle.GetComponent<MLBattle>();
        MLBattleView currentView = view.GetComponent<MLBattleView>();

        currentBattle.view = currentView;

        currentBattle.agent = Instantiate(AgentPrefab);
        currentBattle.enemy = Instantiate(EnemyPrefab);
        currentBattle.agent.transform.SetParent(currentBattle.transform);
        currentBattle.enemy.transform.SetParent(currentBattle.transform);

        currentBattle.BattleSpeed = battleSpeed;

        return currentBattle;
    }
}
