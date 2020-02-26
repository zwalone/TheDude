using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbilityController
{
    private Ability ability;
    private float cooldown;
    public void Equip(){
        //example: give 5 additional damge when gain this skill
        stats.damage.AddModifire(5);
    }    

    public void Use(){
        //play animation
        stats.TakeDamage(20);
        cooldown = 20;
       
    }     
    public void Remove(){
         stats.damage.RemoveModifire(5);
    }

    private void Update() {
        // cooldown --;
    }
}
