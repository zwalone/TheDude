﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralEnemy : Enemy
{
    //N1,N2, W2,E2
    int lastSkill = -1;

    public override int MakeChoice()
    {
        int choice = 0;
        if ( lastSkill != 1) choice = 1;//Decision();
        lastSkill = 1;
        return choice;
    }

    //int Decision()
    //{
    //    if (Stats.Hp < Stats.MaxHP*0.4 && Effects.GetNumberOfEffect() == 0) return 1;
    //    if (Effects.GetNumberOfEffect() == 0) return 1;
    //    if (lastSkill == 1) return 2;
    //    else return 0;

    //}

}
