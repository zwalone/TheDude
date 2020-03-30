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

    public Sprite icon;

    public int Def;

    public int Atk;

    public int Dex;

    public enum Type
    {
        Weapon,
        Helm,
        Breastplate,
        Boots,
    };
    //many others right ? 
}
