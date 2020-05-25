using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffect 
{
    List<object[]> _oneTime;
    List<object[]> _eachTime;
    public AfterEffect()
    {
        _eachTime = new List<object[]>();
        _oneTime = new List<object[]>();
    }
    public void ActivateFunctions()
    {
        EachTimeAction();
        OneTimeAction();
    }

    void EachTimeAction() 
    {
        for (int i = _eachTime.Count - 1; i >= 0; i--)
        {
            var effect = _eachTime[i];
            ModifyStats((string)effect[0], (Entity)effect[1], (int)effect[2]);
            effect[3] = (int)effect[3] - 1;
            if ((int)effect[3] <= 0) _eachTime.Remove(effect);
        }
    }
    void OneTimeAction()
    {
        for (int i = _oneTime.Count-1; i >= 0; i--)
        {
            var effect = _oneTime[i];
            if ((int)effect[3] == 0)
            {
                ModifyStats((string)effect[0], (Entity)effect[1], -(int)effect[2]);
                _oneTime.Remove(effect);
            }
            else
            {
                effect[3] = (int)effect[3] - 1;
            }  
        }
        
    }
    void ModifyStats(string statName, Entity entity, int value)
    {
        if (statName == "Atk") entity.Stats.SetAtk(value);
        else if (statName == "Def") entity.Stats.SetDef(value);
        else if(statName == "Dex") entity.Stats.SetDex(value);
        else if(statName == "Hp") entity.Stats.SetHp(value);
        else if(statName == "FlatDmg") entity.Stats.TakeFlatDamage(value);
        else if(statName == "Dmg") entity.Stats.TakeDamage(value);

    }
    public void SetModifire(string statName, Entity entity, int value, int time)
    {
        ModifyStats(statName, entity, value);
        _oneTime.Add(new object[] { statName, entity, value ,time});
    }

    public void SetEachTurnAction(string statName, Entity entity, int value, int time)
    {
        _eachTime.Add(new object[] { statName, entity, value, time });
    }

    public void ClearAll() 
    {
        _eachTime.Clear();
        foreach (var item in _oneTime)
        {
            item[3] = 0;
        }
    
    }
    public void ResetAll()
    {
        _eachTime.Clear();
        _oneTime.Clear();
    }

    public int GetNumberOfEffect() => _oneTime.Count + _eachTime.Count;
}
