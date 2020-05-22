using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text plName;
    public Text enName;
    public Slider plHp;
    public Slider enHp;
    CharacterStats plStats;
    CharacterStats enStats;
    public Text pAC;
    public Text eAC;


    public void SetHUD()
    {
        plStats = BattleSystem.Instance.player.Stats;
        enStats = BattleSystem.Instance.enemy.Stats;

        plName.text= plStats.CharName;
        enName.text = enStats.CharName;

        plHp.maxValue = plStats.MaxHP;
        enHp.maxValue = enStats.MaxHP;

        plStats.ResetHP();
        enStats.ResetHP();
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        plHp.value = plStats.Hp;
        enHp.value = enStats.Hp;
        //pAC.text = string.Format("AC: {0}/{1}",plStats.ActionPoints,plStats.Dex.Val);
    }
}
