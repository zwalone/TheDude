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
        _cooldownCounter = Cooldown + 1;// Wait turn = n-1 => We add 1 to make it equl
        user.LastAttackType = TypeOfSkill;
        return "NULL";
    }

    public void CalculateDamge(Entity user, Entity opponent, double powerScale)
    {
        CalculateModifire(user, opponent);
        _damage = user.Stats.CalculateDamage() * _modifire * powerScale;
    }
    public double CalculateModifire(Entity user, Entity opponent)
    {
        double SameTypeSkill = Types.SameType(user.Stats.TypeOfEntity, TypeOfSkill);
        double OpponentWeakness = Types.GetAttackTypeModifire(TypeOfSkill, opponent.Stats.TypeOfEntity);
        double ComboBonus = Types.GetPreviousAttackBonus(TypeOfSkill, user.LastAttackType);

        _modifire = SameTypeSkill * OpponentWeakness * ComboBonus;
        return _modifire;
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

    public void ResetParameters()
    {
        _cooldownCounter = 0;
        _modifire = 1;
        _damage = 0;
    }
  
} 
