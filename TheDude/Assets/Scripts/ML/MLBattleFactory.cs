using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MLBattleFactory : MonoBehaviour
{
    public GameObject ViewPrefab;
    public GameObject BattlePrefab;
    public GameObject MainView;

    public Agent AgentPrefab;
    public List<GameObject> EnemiesPrefabs;

    public Transform ParentForBattles;
    public Transform ParentForViews;

    public MLBattle CreateBattle(int battleSpeed, int limitOfTurn, int numOfEnemy)
    {
        var battle = Instantiate(BattlePrefab);
        var view = Instantiate(ViewPrefab);
        battle.transform.SetParent(ParentForBattles);
        view.transform.SetParent(ParentForViews);

        MLBattle currentBattle = battle.GetComponent<MLBattle>();
        MLBattleView currentView = view.GetComponent<MLBattleView>();

        currentBattle.view = currentView;

        currentBattle.agent = Instantiate(AgentPrefab);
        currentBattle.enemyGO = Instantiate(EnemiesPrefabs[numOfEnemy]);
        currentBattle.enemy = currentBattle.enemyGO.GetComponent<Entity>();
        currentBattle.agent.transform.SetParent(currentBattle.transform);
        currentBattle.enemy.transform.SetParent(currentBattle.transform);

        currentBattle.BattleSpeed = battleSpeed;
        currentBattle.limitOfTurn = limitOfTurn;

        return currentBattle;
    }

    public void ChangeEnemy(MLBattle battle,int indexEnemy)
    {
        Destroy(battle.enemyGO);

        battle.enemyGO = Instantiate(EnemiesPrefabs[indexEnemy]);
        battle.enemy = battle.enemyGO.GetComponent<Entity>();
        battle.enemyGO.transform.SetParent(battle.transform);

    }
}
