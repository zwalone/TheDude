using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public void Opt1()
    {
        End();
        StartCoroutine(BattleSystem.Instance.SetupBattle());
    }

    public void Opt2()
    {
        End();
        GameManager.Instance.ChangeScene("Menu");
    }

    public void Opt3()
    {
        End();
        BattleSystem.Instance.enemy.stats.Atk.AddModifire(15);
        StartCoroutine(BattleSystem.Instance.SetupBattle());
    }

    void End() 
    {
        DialogueManager.Instance.EndDialogue();
    }
}
