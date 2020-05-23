using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Entity Opponent { get; set; }
    public CharacterStats Stats;
    public List<Skill> Skills;
    public AfterEffect Effects;
    public Type LastAttackType;

    public Entity()
    {
        Effects = new AfterEffect();
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
        else log.AddToLog($"{Stats.CharName} \nWait for cooldown");

        if(Opponent.Stats.MissLog) log.AddToLog($"{Stats.CharName} Miss ");

        return act;
    }
}
