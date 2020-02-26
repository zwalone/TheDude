using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public void Equip(){
        //example: set armor value on 5
        //show in inventory
        stats.Armor.AddModifire(5);
    }     

    public virtual void Use(){
        //sell item or active its ability
    }     
    public virtual void Remove(){
         //example: set armor value on 5
        //remove from inventory
        stats.Armor.RemoveModifire(5);
    }
}
