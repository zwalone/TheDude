﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using System;

public class MLManager : MonoBehaviour
{
    public int NumOfBattles;
    public int BattleSpeed;
    public double MutationRate;
    public double Crossover;
    public int LimitOfBatttleTurn;
    

    public List<MLBattle> Battles;
    public MLManagerView ManagerView;
    public MLBattleFactory Factory;

    List<int> _totalWins;
    int _generation = 0;
    int _winningRate = 0;
    int _highestscore = 0;
    double _lostBattleScale = 0.7;

    public void Start()
    {
        _totalWins = new List<int>();
        if (PlayerPrefs.HasKey("mutationRate")) MutationRate = Convert.ToDouble(PlayerPrefs.GetString("mutationRate"));
        if (PlayerPrefs.HasKey("crossover")) Crossover = Convert.ToDouble(PlayerPrefs.GetString("crossover"));

        for (int i = 0; i < NumOfBattles; i++)
        {
            Battles.Add(Factory.CreateBattle(BattleSpeed, LimitOfBatttleTurn,0));
        }
        UpdateViewBar();
    }
    public void Update()
    {
        if (BattleFinished()) 
        {
            Train();
        }
    }

    void Train()
    {
        _generation++;
        UpdateWeights();
        CalculateWins();
        foreach (var battle in Battles)
        {
            battle.SetupBattle();
        }
        UpdateViewBar();
    }

    List<double> GetScore()
    {
        List<double> scores = new List<double>();
        foreach (var battle in Battles)
        {
            if (battle.battleWon) scores.Add(battle.agent.GetScore(battle.turn));
            else scores.Add(_lostBattleScale * battle.agent.GetScore(battle.turn));
        }
        if (scores.Count == 0) scores.Add(1.0);
        return scores;
    }

    void UpdateWeights()
    {
        var score = GetScore();

        _highestscore = (int)score.Max();

        //Take Best Entity (Dad)
        int bestEntityDad = score.IndexOf(score.Max());
        score[bestEntityDad] = 0;
        var bestWeightsDad = Battles[bestEntityDad].agent.GetWeights();

        //Take secound best Entity (Mom)
        int bestEntityMom = score.IndexOf(score.Max());
        var bestWeightsMom = Battles[bestEntityMom].agent.GetWeights();

        //Debug.Log($"index  Dad: {bestEntityDad} , index Mom{bestEntityMom}");
        //Debug.Log($"{bestWeightsDad[19]} , {bestWeightsDad[20]} , {bestWeightsDad[100]} , {bestWeightsDad[120]} , {bestWeightsDad[150]}");
        foreach (var battle in Battles)
        {
            battle.agent.PushWeightsFromParents(bestWeightsDad, bestWeightsMom, Crossover , MutationRate); 
        }

        
    }
    bool BattleFinished()
    {
        foreach (var battle in Battles)
        {
            if (battle.battleFinished != true) return false;
        }
        return true;
    }

    void UpdateViewBar()
    {
        ManagerView.ChangeCrossOver(Crossover);
        ManagerView.ChangeMutationRate(MutationRate);
        ManagerView.ChangeGeneration(_generation);
        //ManagerView.ChangeWins(_wins,NumOfBattles);
        ManagerView.ChangeWinningRate(_winningRate);
        ManagerView.ChangeHighestScore(_highestscore);
    }
    void CalculateWins()
    {
         int wins = 0;
        foreach (var battle in Battles)
        {
            if (battle.battleWon) wins++;
        }

        if (_totalWins.Count == 10) _totalWins.RemoveAt(0);
        _totalWins.Add(wins);

        double sum = 0;
        _totalWins.ForEach(x => sum += x) ;

        _winningRate = (int)(sum / _totalWins.Count * 10.0);
    }
}
