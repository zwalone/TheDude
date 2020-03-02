using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : AbilityController
{
    public override void Equip(){
        base.Equip();
        //example: set armor value on 5
        //show in inventory
        //stats.armor.AddModifire(5);
    }     

    public override void Use(){
        base.Use();
        //sell item or active its ability
    }     
    public override void Remove(){
        base.Remove();
         //example: set armor value on 5
        //remove from inventory
        //stats.armor.RemoveModifire(5);
    }
}
