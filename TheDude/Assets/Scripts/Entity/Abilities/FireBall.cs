using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbilityController
{
    private Ability ability;
    private float cooldown;
    public override void Equip(){
        base.Equip();
        //example: give 5 additional damge when gain this skill
        //stats.damage.AddModifire(5);
    }    

    public override void Use(){
        base.Use();
        //play animation
        stats.TakeDamage(20);
        cooldown = 20;
       
    }     
    public override void Remove(){
         //stats.damage.RemoveModifire(5);
         base.Remove();
    }

    private void Update() {
        // cooldown --;
    }
}
