using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffect 
{
    List<object[]> oneTime;
    List<object[]> eachTime;
    public AfterEffect()
    {
        eachTime = new List<object[]>();
        oneTime = new List<object[]>();
    }
    public void ActivateFunctions()
    {
        EachTimeAction();
        OneTimeAction();
    }

    void EachTimeAction() 
    {
        for (int i = eachTime.Count - 1; i >= 0; i--)
        {
            var effect = eachTime[i];
            ModifyStats((string)effect[0], (Entity)effect[1], (int)effect[2]);
            effect[3] = (int)effect[3] - 1;
            if ((int)effect[3] <= 0) eachTime.Remove(effect);
        }
    }
    void OneTimeAction()
    {
        for (int i = oneTime.Count-1; i >= 0; i--)
        {
            var effect = oneTime[i];
            if ((int)effect[3] == 0)
            {
                ModifyStats((string)effect[0], (Entity)effect[1], -(int)effect[2]);
                oneTime.Remove(effect);
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
        oneTime.Add(new object[] { statName, entity, value ,time});
    }

    public void SetEachTurnAction(string statName, Entity entity, int value, int time)
    {
        eachTime.Add(new object[] { statName, entity, value, time });
    }

    public void ClearAll() 
    {
        eachTime.Clear();
        foreach (var item in oneTime)
        {
            item[3] = 0;
        }
    
    }

    public int GetNumberOfEffect() => oneTime.Count + eachTime.Count;
}
