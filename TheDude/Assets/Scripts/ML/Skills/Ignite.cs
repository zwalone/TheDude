using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : Skill
{
    public double PowerScale;
    public int Duration;

    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        CalculateDamge(user, opponent, PowerScale);
        base.Activate(user, opponent);

        //Action
        user.Effects.SetEachTurnAction("FlatDmg", opponent, (int)_damage, Duration);

        //Log
        return $"{user.Stats.CharName}\n Ignite({Duration}): {_damage}/perTurn";

    }
}
