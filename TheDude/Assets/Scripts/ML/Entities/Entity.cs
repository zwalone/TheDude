using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Entity Opponent;
    public CharacterStats Stats;
    public List<Skill> Skills;
    public AfterEffect Effects;

    public Entity()
    {
        Effects = new AfterEffect();
    }

    public virtual void ResetBeforFight()
    {
        Stats.ResetStats();
        Effects.ResetAll();
        foreach (var skill in Skills)
        {
            skill.ResetParameters();
        }

    }
    public void UpdateCooldown()
    {
        foreach (var skill in Skills)
        {
            skill.CoolDownDecrease();
        }
    }
    public virtual int MakeChoice()
    {
        float maxInxSkill = Skills.Count;
        int rnd = (int)(UnityEngine.Random.Range(0.0f, maxInxSkill) - 0.01);
        return rnd;
    }

    public int MakeAction(LogView log)
    {
        int act = MakeChoice();
        Stats.MissLog = false;

        if (Skills[act].CanActivate())
        {
            string logFromAction = Skills[act].Activate(this, Opponent);
            log.AddToLog(logFromAction);
        }
        else log.AddToLog($"{Stats.CharName} \nWait for cooldown({act})");

        if(Opponent.Stats.MissLog) log.AddToLog($"{Stats.CharName} Miss ");

        return act;
    }
}
