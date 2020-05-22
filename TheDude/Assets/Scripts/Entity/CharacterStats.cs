using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string CharName;
    public Type TypeOfEntity;

    #region Properties
    [SerializeField]
    private int maxHP;
    public int MaxHP 
    { 
        get{return maxHP;}
        set{maxHP = value;}
    }
    private int actionPoints;
    public int ActionPoints 
    { 
        get{return actionPoints;}
        set
        {
            if(actionPoints + value > Dex.Val) 
                actionPoints = Dex.Val;
            else 
                actionPoints += value;
        }

    }
    [SerializeField]
    private int hp;
    public int Hp 
    { 
        get{return hp;}
        set
        {
            if(hp+value<0) hp = 0;
            else if(hp+value > MaxHP) hp = MaxHP;
            else hp += value;
        }
    }
    public Stat Atk;
    public Stat Def;
    //Number of action in turn
    public Stat Dex;

    #endregion
    public void TakeDamage(double dmg)
    {
        //double tmp = Def.GetModifires();
        //tmp += dmg;
        TakeFlatDamage(-dmg);
    }
    public void TakeFlatDamage(double dmg)
    {
        if (dmg < 0)
        {
            Hp = (int)dmg;
        }
    }
    public double CalculateDamage()
    {
        return Atk.Val;
    }

    public bool CastSkill(int cost)
    {
        if(cost <= ActionPoints)
        {
            ActionPoints = -cost;
            return true;
        }
        else return false;
    }

    public bool IsAlive()
    {
        if(Hp <=0) return false;
        else return true;
    }

    public void ResetHP() => Hp = MaxHP;
    public void ResetAC() => ActionPoints = Dex.Val;

}
