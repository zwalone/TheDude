using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string charName;
    public Stat hp;
    public Stat atk;
    //Number of action in turn
    public Stat sp;
    public Stat def;
    //Power of effects 
    public Stat Atr;

    //we will set later what stats exactly we need
   public bool TakeDamage(int dmg)
    {
        hp.value = dmg;
        if(hp.value <= 0) return true;
        else return false;
    }

}
