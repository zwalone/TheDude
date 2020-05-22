using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Skill
{
    public int DexBuff;
    public int Duration;

    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        base.Activate(user, opponent);

        //Action
        user.Effects.SetModifire("Dex", user, DexBuff, Duration);

        //Log
        return $"{user.Stats.CharName}\n Guard({Duration}): Dex+ {DexBuff}";
    }
}
