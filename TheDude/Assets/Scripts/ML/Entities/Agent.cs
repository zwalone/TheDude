﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class Agent : Entity
{
    Network _network;
    double _score;

    public double HpScale;
    public double ModifireScale;

    private void Start()
    {
        _network = new Network(18,8,8,10);
    }
    public double GetScore()=> _score * ModifireScale + (Opponent.Stats.Hp / Opponent.Stats.MaxHP) * HpScale;
   
    public override int MakeChoice()
    {
        _network.PushInputValues(GetInputs());
        List<double> choices = _network.GetOutput();

        int num = 0; 
        for (int i = 0; i < 10; i++)
        {
            num = choices.IndexOf(choices.Max());
            if (Skills[num].Cooldown == 0) break;
            else choices[num] = 0;
        }

        _score += Skills[num].CalculateModifire(this,Opponent);

        return num;

        //return base.MakeChoice();

    }

    double[] GetInputs()
    {
        CharacterStats Ostats =  Opponent.Stats;
        double[] inputs = new double[] { Stats.Hp / Stats.MaxHP * 100, Stats.Atk, Stats.Def, Stats.Dex, 
            Ostats.Hp / Ostats.MaxHP * 100, Ostats.Atk, Ostats.Def, Ostats.Dex,0,0,0,0,0,0,0,0,0,0};

        inputs[(int)Stats.TypeOfEntity+8] = 1;
        inputs[(int)Opponent.Stats.TypeOfEntity + 13] = 1;

        return inputs;
    }
}
