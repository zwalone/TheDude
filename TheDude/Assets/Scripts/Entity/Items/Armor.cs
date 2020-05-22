using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor //: AbilityController
{

    [SerializeField]
    private Item item;

    private string _name;
    private string _description;
    private int _cost;
    private Sprite _icon;
    private int _armor;
    private int _dmg;
    private Type _type;
    public enum Type
    {
        Weapon,
        Helm,
        Breastplate,
        Boots,
    }

    //Probles with type 
    public void Start()
    {
        _name = item.name;
        _description = item.Description;
        _cost = item.cost;
        _icon = item.icon;
        _armor = item.armor;
        _dmg = item.dmg;
        _type = (Type)item.type;

    }

    public void Equip(){

        //Tutaj Inventory Dodaj Iteam;
        
        //example: set armor value on 5
        //show in inventory
        //stats.armor.AddModifire(5);
    }

    public virtual void Use(){
        //sell item or active its ability
    }     
    //public override void Remove(){
    //    base.Remove();
    //     //example: set armor value on 5
    //    //remove from inventory
    //    //stats.armor.RemoveModifire(5);
    //}

    public string Name { get {return _name; }}
    public string Description { get { return _description; } }
    public int Cost { get { return _cost; } }
    public Sprite Icon { get { return _icon; } }
    public int Armorr { get { return _armor; } }
    public int Dmg { get { return _dmg; } }
    public Type Typee { get { return _type; } }
}
