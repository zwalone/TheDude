using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlots : MonoBehaviour
{
    public Image Icon;
    AbilityController ability;

    public void AddItem(AbilityController item)
    {
        ability = item;

        Icon.sprite = item.GetComponent<Fireball>().Icon;
        Icon.enabled = true;
        //Add modyfy if needed
    }

    public void UnEqiup()
    {
        if (ability != null)
        {
            if (Inventory.instace.UnEquip(ability))
            {
                ability = null;
                Icon.sprite = null;
                Icon.enabled = false;
            }
        }
    }

}
