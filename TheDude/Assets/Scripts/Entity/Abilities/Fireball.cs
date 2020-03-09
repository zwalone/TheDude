using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : AbilityController
{
    public Ability lvl;
    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        int dmg = (int)(BattleSystem.Instance.player.stats.atk.value * lvl.dmgscale); 
        Debug.Log("Atakuje " + dmg);
        BattleSystem.Instance.enemy.stats.TakeDamage(-dmg);
    }     
    public override void Remove(){
        base.Remove();
    }

}
