using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : AbilityController
{
    public Image icon;

    AbilityController item;


    //ADD
    public void AddItem(AbilityController newItem)
    {
        item = newItem;
        if (newItem is Armor)
        {
            icon.sprite = item.GetComponent<Armor>().Icon;
            icon.enabled = true;
        }
        else if (newItem is Fireball)
        {
            icon.sprite = item.GetComponent<Fireball>().Icon;
            icon.enabled = true;
        }
        
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }


    public void Equip()
    {
        //efect happend after equip ability like flat modifires or passive skills
        if (item != null)
        {
            if (Inventory.instace.Equip(item))
            {
                //Destroy Item
                //Destroy(item);
                //item = null;
                //icon.sprite = null;
                //icon.enabled = false;
            }
        }
    }
    public void Use()
    {
        //active skills like cast spell attacks and so on
    }
    public void Remove()
    {
        //remove skill and undo changes
    }

}
