using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;

    public GameObject enemyGO;

    private void Awake() 
    {
        //manager = DialogueManager.Instance;
    }
    public void TriggerEncounter()
    {
        //manager.StartDialogue(dialogue);
        Debug.Log("Loading...");
        GameManager.Instance.nextEnemy = enemyGO;
        GameManager.Instance.ChangeScene("BattleScene");
    }
    
    public void StartBattle()
    {
       // manager.StartDialogue(dialogue);
    }
}
