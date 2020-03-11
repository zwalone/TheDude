using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : AbilityController
{
    public float dmgscale;
    BattleSystem bs;
    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        bs=BattleSystem.Instance;

        int dmg = (int)(bs.player.stats.atk.value * dmgscale); 
        Debug.Log("Atakuje " + dmg);
        bs.enemy.stats.TakeDamage(-dmg);
        bs.afterEffects += Ignite;
    }     
    public override void Remove(){
        base.Remove();
    }

    void Ignite()
    {
        int dmg = (int)(bs.player.stats.atk.value * dmgscale*0.5);
        Debug.Log("Podpalam " + dmg);
        bs.afterEffects -= Ignite;
    }

}
