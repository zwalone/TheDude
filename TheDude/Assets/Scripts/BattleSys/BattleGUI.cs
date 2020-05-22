using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour
{
    [SerializeField]
    public Text Info;
    public BattleSystem bs;
    Queue<string> massages;
    bool onScreen;

    void Start()
    {
        massages = new Queue<string>();
        onScreen = false;
    }

    void Update()
    {
        if(massages.Count != 0 && !onScreen)
        {
            onScreen = true;
            StartCoroutine(ShowMassage(massages.Dequeue()));
        }
    }
    public void OnR1Buttom()
    {
        bs.MakeChoice(0);
    }
    public void OnR2Buttom()
    {
        bs.MakeChoice(1);
    }
    public void OnR3Buttom()
    {
        bs.MakeChoice(2);
    }
    public void EndTurn()
    {
        bs.NextStage();
    }

    public void SetInfo(string str)
    {
        massages.Enqueue(str);
    }

    public IEnumerator ShowMassage(string str)
    {
        Info.text = str;
        yield return new WaitForSeconds(1f);
        Info.text = "";
        onScreen = false;
    }
}
