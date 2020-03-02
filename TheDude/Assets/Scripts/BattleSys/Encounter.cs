using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;

    private void Awake() 
    {
        manager = DialogueManager.Instance;
    }
    public void TriggerEncounter()
    {
        manager.StartDialogue(dialogue);


    }
}
