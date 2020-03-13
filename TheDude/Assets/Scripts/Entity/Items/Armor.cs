using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : AbilityController
{
    [SerializeField]
    private Item item;
    public void Equip(){
        
        //Tutaj Inventory Dodaj Iteam;


        //example: set armor value on 5
        //show in inventory
        //stats.armor.AddModifire(5);

    }     

    public virtual void Use(){
        //sell item or active its ability
    }     
    public virtual void Remove(){
         //example: set armor value on 5
        //remove from inventory
        //stats.armor.RemoveModifire(5);
    }
}
