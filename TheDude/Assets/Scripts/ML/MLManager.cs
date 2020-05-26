using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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

    int _wins;
    double _totalWins = 0;
    int _generation = 0;
    int _winningRate = 0;

    public void Start()
    {
        if (PlayerPrefs.HasKey("mutationRate")) MutationRate = Convert.ToDouble(PlayerPrefs.GetString("mutationRate"));
        if (PlayerPrefs.HasKey("crossover")) Crossover = Convert.ToDouble(PlayerPrefs.GetString("crossover"));

        for (int i = 0; i < NumOfBattles; i++)
        {
            Battles.Add(Factory.CreateBattle(BattleSpeed, LimitOfBatttleTurn));
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
            scores.Add(battle.agent.GetScore());
        }
        return scores;
    }

    void UpdateWeights()
    {
        var score = GetScore();

        //Take Best Entity (Dad)
        int bestEntityDad = score.IndexOf(score.Max());
        score[bestEntityDad] = 0;
        var bestWeightsDad = Battles[bestEntityDad].agent.GetWeights();

        //Take secound best Entity (Mom)
        int bestEntityMom = score.IndexOf(score.Max());
        var bestWeightsMom = Battles[bestEntityMom].agent.GetWeights();
        

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
        ManagerView.ChangeWins(_wins,NumOfBattles);
        ManagerView.ChangeWinningRate(_winningRate);
    }
    void CalculateWins()
    {
        _wins = 0;
        foreach (var battle in Battles)
        {
            if (battle.battleWon) _wins++;
        }
        _totalWins += _wins;
        _winningRate = (int)(100.0 * (_totalWins / (_generation * NumOfBattles)));
    }
}
