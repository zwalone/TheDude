using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnAll : Skill
{
    public double PowerScale;
    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        CalculateDamge(user, opponent, PowerScale);
        base.Activate(user, opponent);

        //Action
        opponent.Stats.TakeDamage(_damage);
        user.Stats.TakeDamage(_damage);

        //Log
        return $"{user.Stats.CharName}\n BurnAll: {_damage}";
    }

    public int GetApproximation(Entity user, Entity opponent)
    {
        CalculateDamge(user, opponent, PowerScale);
        return (int)_damage;
    }
}
