using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrosion : Skill
{
    public int DefDebuff;
    public int Duration;
    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        base.Activate(user, opponent);

        //Action
        user.Effects.SetModifire("Def", opponent, -DefDebuff, Duration);

        //Log
        return $"{opponent.Stats.CharName}\n Corrosion({Duration}): Def- {DefDebuff}";
    }
}
