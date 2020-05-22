using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : Skill
{
    public double PowerScale;
    public int DexDebuff;
    public int Duration;
    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        CalculateDamge(user, opponent, PowerScale);
        base.Activate(user, opponent);

        //Action
        opponent.Stats.TakeDamage(_damage);
        user.Effects.SetModifire("Dex", opponent, DexDebuff, Duration);

        //Log
        return $"{user.Stats.CharName}\n Earthquake({Duration}): {_damage} Dex- {DexDebuff}";

    }
}
