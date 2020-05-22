using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{ 
    public GameObject enemyGO;
    public void TriggerEncounter()
    {
        //manager.StartDialogue(dialogue);
        Debug.Log("Loading...");
        GameManager.Instance.nextEnemy = enemyGO;
        GameManager.Instance.ChangeScene("BattleScene");
    }
}
