using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string CharName;
    public Type TypeOfEntity;
    public bool MissLog;

    #region Properties
    [SerializeField]
    private int maxHP;
    public int MaxHP 
    { 
        get{return maxHP;}
        set{maxHP = value;}
    }

    [SerializeField]
    private int hp;
    public int Hp 
    { 
        get{return hp;}
        set{ hp = Value0To100(value, hp);}
    }
    [SerializeField]
    private int atk;
    public int Atk
    {
        get { return atk; }
        set { atk = Value0To100(value, atk); }
    }
    [SerializeField]
    private int def;
    public int Def
    {
        get { return atk; }
        set { def = Value0To100(value, def); }
    }
    [SerializeField]
    private int dex;
    public int Dex
    {
        get { return dex; }
        set { dex = Value0To100(value, dex); }
    }

    #endregion

    int Value0To100(int value, int stat)
    {
        int sum = stat + value;
        if (sum < 0) return 0;
        else if (sum > 100) return 100;
        else return sum;

    }
    public void TakeDamage(double dmg)
    {
        if (Dodge()) TakeFlatDamage(Def - dmg);

    }
    private bool Dodge()
    {
        int rnd = (int)UnityEngine.Random.Range(0.0f, 100.0f);
        if (rnd > Dex) return true;
        else 
        {
            MissLog = true;
            return false;
        }
        
    }

    public void TakeFlatDamage(double dmg)
    {
        int value = (int)-dmg;
        if (value < 0)
        {
            Hp = (int)value;
        }
    }
    
    public bool IsAlive()
    {
        if(Hp <=0) return false;
        else return true;
    }
    public double CalculateDamage() => Atk;
    public void ResetHP() => Hp = MaxHP;

}
