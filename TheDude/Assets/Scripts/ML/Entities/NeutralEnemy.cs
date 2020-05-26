using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralEnemy : Enemy
{
    //N1,N2, W2,E2
    int lastSkill = -1;

    public override int MakeChoice()
    {
        int choice = Decision();
        lastSkill = choice;
        return choice;
    }

    int Decision()
    {
        if (Skills[3].CanActivate() && Stats.ProcentOfHp() < 90) return 3;
        if (Skills[2].CanActivate() && lastSkill == 1) return 2;
        if (Skills[0].CanActivate() && lastSkill == 2) return 0;
        if (Skills[0].CanActivate()) return 0;
        return 1;

    }

}
