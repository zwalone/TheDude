using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ability", menuName ="Ability")]
public class Ability : ScriptableObject
{
    //TODO Energy or Mana Costs for spell

    //TODO Efects type 

    public new string name;

    public float dmgscale;

    public float heal;

    public int costSp;

    public List<Effects> efects;

    public Sprite icon;

    
}
