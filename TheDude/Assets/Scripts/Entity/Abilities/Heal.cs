using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : AbilityController
{
    BattleSystem bs;
    public int healValue;
    public int defBuff;
    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        bs = BattleSystem.Instance;

        bs.player.stats.Hp = healValue;
        bs.GUI.SetInfo("Heal +" + healValue + "HP");

        bs.player.stats.Def.AddModifire(defBuff);
        bs.GUI.SetInfo("Def Buff +" + defBuff + " Armor");

    }     
    public override void Remove(){
        base.Remove();
    }
}
