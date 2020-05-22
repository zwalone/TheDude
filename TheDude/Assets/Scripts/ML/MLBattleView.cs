using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MLBattleView : MonoBehaviour
{
    public Text agName;
    public Text enName;
    public Slider agHp;
    public Slider enHp;
    CharacterStats agStats;
    CharacterStats enStats;
    public Text statsView;
    public Text BattleStateTxt;
    public Image BattleStateImg;
    public MLSkillHeatMap HeatMap;
    public LogView log;
    public GameObject logGO;

    public void ActivateDiode(int num) => HeatMap.LightDiode(num);
    public void ActivateLog() => logGO.SetActive(!logGO.activeSelf);
    public bool LogOpen() => logGO.activeSelf;
    public void SetView(Entity agent, Entity enemy)
    {
        agStats = agent.Stats;
        enStats = enemy.Stats;

        agName.text = agStats.CharName;
        enName.text = enStats.CharName;

        agHp.maxValue = agStats.MaxHP;
        enHp.maxValue = enStats.MaxHP;

        agStats.ResetHP();
        enStats.ResetHP();

        BattleStateTxt.text = "Fighting...";
        UpdateView();
    }

    public string UpdateView()
    {
        agHp.value = agStats.Hp;
        enHp.value = enStats.Hp;
        string stats = string.Format(
            "A ATK: {0} DEF: {1} DEX: {2}\n" +
            "E ATK: {3} DEF: {4} DEX: {5}",
            agStats.Atk, agStats.Def, agStats.Dex,
            enStats.Atk, enStats.Def, enStats.Dex
            );
        statsView.text = stats;
        stats = $"A HP: {agStats.Hp} | E HP: {enStats.Hp}\n" + stats;
        return stats.ToLower();
    }
    public void BattleWon()
    {
        BattleStateTxt.text = "WON";
        BattleStateImg.color = Color.green;
    }

    public void BattleLost()
    {
        BattleStateTxt.text = "LOST";
        BattleStateImg.color = Color.red;
    }



}

