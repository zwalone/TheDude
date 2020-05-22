using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected int _cooldownCounter;
    protected double _damage;
    protected double _modifire;

    public int Cooldown;
    public Type TypeOfSkill;

    public virtual string Activate(Entity user, Entity opponent) 
    {
        _cooldownCounter = Cooldown;
        user.LastAttackType = TypeOfSkill;
        return "NULL";
    }

    public void CalculateDamge(Entity user, Entity opponent, double powerScale)
    {
        CalculateModifire(user, opponent);
        _damage = user.Stats.CalculateDamage() * _modifire * powerScale;
    }
    public void CalculateModifire(Entity user, Entity opponent)
    {
        double SameTypeSkill = Types.SameType(user.Stats.TypeOfEntity, TypeOfSkill);
        double OpponentWeakness = Types.GetAttackTypeModifire(TypeOfSkill, opponent.Stats.TypeOfEntity);
        double ComboBonus = Types.GetPreviousAttackBonus(TypeOfSkill, user.LastAttackType);

        _modifire = SameTypeSkill * OpponentWeakness * ComboBonus;
    }
    public bool CanActivate()
    {
        if (_cooldownCounter <= 0) return true;
        else return false;
    }
    public void CoolDownDecrease()
    {
        if (_cooldownCounter > 0) _cooldownCounter--;
    }
  
} 
