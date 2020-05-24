using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string CharName;
    public Type TypeOfEntity;
    public bool MissLog;

    [Range(0, 100)]
    public int MaxHP;
    [Range(0, 100)]
    public int BaseAtk;
    [Range(0, 100)]
    public int BaseDef;
    [Range(0, 100)]
    public int BaseDex;

    [NonSerialized]
    public int Hp;
    [NonSerialized]
    public int Atk;
    [NonSerialized]
    public int Def;
    [NonSerialized]
    public int Dex;

    public void SetDex(int modifire) => Dex = Value0To100(Dex + modifire);
    public void SetDef(int modifire) => Def = Value0To100(Def + modifire);
    public void SetAtk(int modifire) => Atk = Value0To100(Atk + modifire);
    public void SetHp(int modifire) => Hp = Value0To100(Hp + modifire);

    int Value0To100(int value)
    {
        if (value < 0) return 0;
        else if (value > 100) return 100;
        else return value;

    }
    public void ResetStats()
    {
        Atk = BaseAtk;
        Def = BaseDef;
        Dex = BaseDex;
        Hp = MaxHP;
    }
    public void TakeDamage(double dmg)
    {
        if (Dodge()) TakeFlatDamage(dmg - Def);

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
        if (value < 0) SetHp((int)value);
        
    }
    
    public bool IsAlive()
    {
        if(Hp <=0) return false;
        else return true;
    }
    public double CalculateDamage() => Atk;

}
