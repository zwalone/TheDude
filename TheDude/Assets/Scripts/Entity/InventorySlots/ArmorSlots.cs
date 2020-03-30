using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorSlots : AbilityController
{
    public Type type;
    public Image Icon;
    AbilityController Armor;
    public enum Type
    {
        Weapon,
        Helm,
        Breastplate,
        Boots,
    }

    public void AddItem(AbilityController item)
    {

        //TODO Check Type of item
        if (item.GetComponent<Armor>().Typee.ToString() == type.ToString())
        {
            Armor = item;

            Icon.sprite = item.GetComponent<Armor>().Icon;
            Icon.enabled = true;

            CharacterStats playerStat = GetComponentInParent<CharacterStats>();


        }
        //ADD Modyfire
        

    }

    public void Remove()
    {
        //Destroy Item if enemy steal your weapon or somethig TODO LATER
    }

    public void UnEqiup()
    {
        //Go back to Main inventory
        if (Armor != null)
        {
            if (Inventory.instace.UnEquip(Armor))
            {
                Armor = null;
                Icon.sprite = null;
                Icon.enabled = false;
            }
        }
        
        //Remove Modyfire
    }

}
