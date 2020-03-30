using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireball : AbilityController
{
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private int _cost;
    public float dmgscale;
    BattleSystem bs;


    public override void Equip(){
        base.Equip();
    }
    public override void Use(){
        base.Use();
        bs=BattleSystem.Instance;

        int dmg = (int)(bs.player.stats.Atk.Val * dmgscale); 
        Debug.Log("Atakuje " + dmg);
        bs.enemy.stats.TakeDamage(-dmg);
        bs.afterEffects += Ignite;
    }     
    public override void Remove(){
        base.Remove();
    }

    void Ignite()
    {
        int dmg = (int)(bs.player.stats.Atk.Val * dmgscale*0.5);
        bs.GUI.SetInfo("Burn!");
        bs.enemy.stats.TakeDamage(-dmg);
        bs.afterEffects -= Ignite;
    }

    public Sprite Icon { get { return _icon; } }
    public int Cost { get { return cost; }}
}
