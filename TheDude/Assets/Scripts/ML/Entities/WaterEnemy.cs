using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : Enemy
{
    //W1, W2, A2, E2 --Cooldown 2,2,4,5
    int lastSkill = -1;
    public override int MakeChoice()
    {
        int choice = Decision();
        lastSkill = choice;
        return choice;
    }

    int Decision()
    {
        if (Skills[2].CanActivate() && Stats.ProcentOfHp() < 90) return 2;
        if (Skills[3].CanActivate() && Stats.ProcentOfHp() < 90) return 3;
        if (Skills[0].CanActivate() && lastSkill == 2) return 0;
        if (Skills[0].CanActivate() && lastSkill == 1) return 0;
        return 1;

    }

}
