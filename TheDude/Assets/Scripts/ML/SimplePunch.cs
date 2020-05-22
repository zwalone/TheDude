using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePunch : Skill
{
    public SimplePunch()
    {
        TypeOfSkill = Type.Fire;
    }
    public override void Activate(Entity user, Entity opponent)
    {
        base.Activate(user, opponent);
        double damage = user.Stats.CalculateDamage() * _modifire;
        Debug.Log($"{user.Stats.CharName} Atakuje za {damage}");
        opponent.Stats.TakeDamage(damage);
    }

}
