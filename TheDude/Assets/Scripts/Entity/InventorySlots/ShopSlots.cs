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
        icon.GetComponent<Image>().sprite = item.GetComponent<Armor>().Icon;
    }

    //Add Cost
    public void BuyItem()
    {
        if (item != null)
        {
            if (Inventory.instace.AddItem(item))
            {
                //Destroy Item
                //Destroy(item);
                item = null;
                icon.GetComponent<Image>().sprite = null;
            }
        }
    }
}
