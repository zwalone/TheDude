using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : AbilityController
{
    public float dmgscale;
    BattleSystem bs;
    int counter;
    public int explodeTime;
    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        bs = BattleSystem.Instance;
        counter++;
        bs.GUI.SetInfo("Bomb Planted");
        if(explodeTime == -1 )
        {
            explodeTime = bs.turn+3;
            bs.afterEffects += Explode;
        }
            
    }     
    public override void Remove(){
        base.Remove();
    }

    void Explode()
    {
        if(bs.turn == explodeTime)
        {
            int dmg = (int)(bs.player.stats.Atk.Val * dmgscale*counter*counter);
            bs.GUI.SetInfo("EXPLODE!!!");
            bs.enemy.stats.TakeDamage(-dmg);
            bs.afterEffects -= Explode;
            explodeTime = -1;
        }

    }
}
