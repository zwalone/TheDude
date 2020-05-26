using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEnemy : Enemy
{
    //E1, E2, N1, A2
    int lastSkill = -1;

    public override int MakeChoice()
    {
        int choice = Decision();
        lastSkill = choice;
        return choice;
    }

    int Decision()
    {
        if (Skills[3].CanActivate() && Opponent.Effects.GetNumberOfEffect() > 1) return 3;
        if (Skills[1].CanActivate() && Stats.ProcentOfHp() < 80) return 1;
        if (Skills[2].CanActivate() && lastSkill == 0) return 2;
        else return 0;

    }

}
