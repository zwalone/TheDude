using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item")]
public class Item : ScriptableObject
{
    public Type type;

    public new string name;

    public string Description;

    public int cost;

    //public float heal;

    public Sprite icon;

    public int armor;

    public int dmg;

    public enum Type
    {
        Weapon,
        Helm,
        Breastplate,
        Boots,
    };
    //many others right ? 
}
