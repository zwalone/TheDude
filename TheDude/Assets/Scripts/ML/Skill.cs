using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected int Hold { get; set; }
    protected Type TypeOfSkill { get; set; }

    protected double _modifire;
    public virtual void Activate(Entity user, Entity opponent) 
    {
        double SameTypeSkill = Types.SameType(user.Stats.TypeOfEntity,TypeOfSkill);
        double OpponentWeakness = Types.GetAttackTypeModifire(TypeOfSkill,opponent.Stats.TypeOfEntity);

        _modifire =  SameTypeSkill * OpponentWeakness;
    }
    public bool CanActivate(Entity user, Entity opponent) { return true; }

} 
