using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlots : AbilityController
{
    public AbilityController item;
    public GameObject icon;
    public Text priceText;
    private new int cost;

    public void Start()
    {
        //Get Item and cost  
        if (item is Armor)
        {
            icon.GetComponent<Image>().sprite = item.GetComponent<Armor>().Icon;
            cost = item.cost;
        }
        else if (item is Fireball)
        {
            icon.GetComponent<Image>().sprite = item.GetComponent<Fireball>().Icon;
            cost = item.GetComponent<Fireball>().Cost;
        }

        priceText.text = cost.ToString();
    }

    public void BuyItem()
    {
        if (item != null)
        {
            //Check Cost items and money Player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.GetComponent<CharacterStats>().Money > cost)
            {
                if (Inventory.instace.AddItem(item))
                {
                    item = null;
                    icon.GetComponent<Image>().sprite = null;
                    player.GetComponent<CharacterStats>().Money = -cost;
                }
                else
                {
                    Debug.Log("Inventory full");
                }
            }
            else
            {
                Debug.Log("No enough money !");
            }

        }
    }
}
