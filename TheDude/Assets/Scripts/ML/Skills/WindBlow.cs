using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlow : Skill
{
    public int HealHp;
    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        base.Activate(user, opponent);

        //Action
        opponent.Effects.ClearAll();
        user.Stats.Hp = HealHp;

        //Log
        return $"{user.Stats.CharName}\n WindBlow: HP+ {HealHp}";
    }
}
