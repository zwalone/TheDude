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
    public int Generation;
    public int HighestScore;
    public int LimitOfBatttleTurn;

    public List<MLBattle> Battles;
    public MLManagerView ManagerView;
    public MLBattleFactory Factory;

    public void Start()
    {
        if (PlayerPrefs.HasKey("mutationRate")) MutationRate = Convert.ToDouble(PlayerPrefs.GetString("mutationRate"));
        if (PlayerPrefs.HasKey("crossover")) Crossover = Convert.ToDouble(PlayerPrefs.GetString("crossover"));

        ManagerView.MutationRateText.text = $"Mutation Rate: {MutationRate * 100.0}%"; 
        ManagerView.CrossOverText.text = $"Crossover : {Crossover * 100.0}%";
        for (int i = 0; i < NumOfBattles; i++)
        {
            Battles.Add(Factory.CreateBattle(BattleSpeed, LimitOfBatttleTurn));
        }
        
    }

    public void Update()
    {
        if (BattleFinished()) 
        {
            Train();
            Generation++;
            ManagerView.ChangeGeneration(Generation);
        }
        
    }

    void Train()
    {
        UpdateWeights();
        foreach (var battle in Battles)
        {
            battle.SetupBattle();
        }
          
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
}
