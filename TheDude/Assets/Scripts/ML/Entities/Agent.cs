﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class Agent : Entity
{
    Network _network = new Network(18, 2, 8, 10);
    double _score;

    public double HpScale;
    public double ModifireScale;

    public double GetScore(int turns) 
    {
        return _score* ModifireScale +(Opponent.Stats.Hp / Opponent.Stats.MaxHp) * HpScale + (100.0-turns)/100;
    } 
    public List<double> GetWeights() => _network.GetWeights();
    public void PushWeights(List<double> weights) => _network.PushWeights(weights);

    //Method to crossover Parents
    public void PushWeightsFromParents(List<double> dad, List<double> mom, double crossoverPercent = 0.05, double mutationRate = 0.01)
        => _network.PushWeightsFromParents(dad , mom, crossoverPercent, mutationRate);

    public override int MakeChoice()
    {
        _network.PushInputValues(GetInputs());

        List<double> choices = _network.GetOutput();

        int num = 0;
        for (int i = 0; i < 10; i++)
        {
            num = choices.IndexOf(choices.Max());
            if (Skills[num].CanActivate()) break;
            else choices[num] = 0;
        }

        _score += Skills[num].CalculateModifire(this, Opponent);

        return num;

    }

    double[] GetInputs()
    {
        CharacterStats Ostats =  Opponent.Stats;
        double[] inputs = new double[] { (double)Stats.Hp / (double)Stats.MaxHp * 100.0, (double)Stats.Atk, (double)Stats.Def,
            (double)Stats.Dex,
            (double)Ostats.Hp / (double)Ostats.MaxHp * 100, (double)Ostats.Atk, (double)Ostats.Def, (double)Ostats.Dex,
            0,0,0,0,0,0,0,0,0,0};

        inputs[(int)Stats.TypeOfEntity+8] = 1;
        inputs[(int)Opponent.Stats.TypeOfEntity + 13] = 1;

        //Percent of Stats
        for (int i = 0; i < 8; i++)
        {
            inputs[i] = inputs[i] / 100.0;
        }

        return inputs;
    }
}
