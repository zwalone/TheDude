using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : Skill
{
    public int HealHp;
    public int DefBuff;
    public int Duration;

    public override string Activate(Entity user, Entity opponent)
    {
        //Calculate
        base.Activate(user, opponent);

        //Action
        user.Stats.SetHp(HealHp);
        user.Effects.SetModifire("Def", user, DefBuff, Duration);

        //Log
        return $"{user.Stats.CharName}\n Roots({Duration}): Hp+ {HealHp} Def+ {DefBuff}";
        
    }
}
