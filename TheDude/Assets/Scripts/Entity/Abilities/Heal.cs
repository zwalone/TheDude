using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : AbilityController
{
    BattleSystem bs;
    public int healValue;
    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        bs=BattleSystem.Instance;

        bs.player.stats.hp.value = healValue;
    }     
    public override void Remove(){
        base.Remove();
    }
}
