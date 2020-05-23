using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : Enemy
{
    //W1, W2, N1, E1
    int lastSkill = -1;

    public override int MakeChoice()
    {
        int choice = Decision();
        lastSkill = choice;
        return choice;
    }

    int Decision()
    {
        if (Effects.GetNumberOfEffect() == 0 && Skills[3].CanActivate()) return 3;
        if (lastSkill == 3) return 1;
        if (lastSkill == 1) return 0;
        else return 2;

    }


}
