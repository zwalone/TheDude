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

    public void SetHUD()
    {
        plStats = BattleSystem.Instance.player.stats;
        enStats = BattleSystem.Instance.enemy.stats;

        plName.text= plStats.charName;
        enName.text = enStats.charName;

        plHp.maxValue = plStats.hp.maxValue;
        enHp.maxValue = enStats.hp.maxValue;

        UpdateHUD();
    }

    public void UpdateHUD()
    {
        plHp.value = plStats.hp.value;
        enHp.value = enStats.hp.value;
    }
}
