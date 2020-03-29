using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlots : AbilityController
{
    public AbilityController item;
    public GameObject icon;

    public void Start()
    {
        //Add others type of ability or change ?  ?  ? 
        if (item is Armor)
        {
            icon.GetComponent<Image>().sprite = item.GetComponent<Armor>().Icon;
        }
        else if (item is Fireball)
        {
            icon.GetComponent<Image>().sprite = item.GetComponent<Fireball>().Icon;
        }
        
    }

    //Add Cost
    public void BuyItem()
    {
        if (item != null)
        {
            if (Inventory.instace.AddItem(item))
            {
                item = null;
                icon.GetComponent<Image>().sprite = null;
            }
        }
    }
}
