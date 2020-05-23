using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Entity
{
    //F1,F2,A1,N2
    int lastSkill = -1;

    public override int MakeChoice()
    {
        int choice = Decision();
        lastSkill = choice;
        return choice;
    }

    int Decision()
    {
        if (Stats.Hp - Opponent.Stats.Hp > 20) return 3;
        
        BurnAll burn = Skills[1] as BurnAll;
        int dmg = burn.GetApproximation(this, Opponent);
        if (dmg > Opponent.Stats.Hp && dmg < Stats.Hp) return 1;
        
        if (lastSkill == 2) return 0;
        else return 2;
        
    }
}
