﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : Skill
{
    public double PowerScale;
    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        CalculateDamge(user, opponent, PowerScale);
        base.Activate(user, opponent);

        //Action
        opponent.Stats.TakeDamage(_damage);

        //Log
        return $"{user.Stats.CharName}\n Tornado: {_damage}";
    }
}