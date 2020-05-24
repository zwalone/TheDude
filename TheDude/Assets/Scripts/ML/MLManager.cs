﻿using System.Collections;
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
    //Inne parametry...
    public List<MLBattle> Battles;
    public List<MLBattleView> Views;

    public MLManagerView ManagerView;
    public GameObject ViewPrefab;
    public GameObject BattlePrefab;
    public GameObject MainView;

    public Agent AgentPrefab;
    public Entity EnemyPrefab;
    public void Start()
    {
        if (PlayerPrefs.HasKey("mutationRate")) MutationRate = Convert.ToDouble(PlayerPrefs.GetString("mutationRate"));
        if (PlayerPrefs.HasKey("crossover")) Crossover = Convert.ToDouble(PlayerPrefs.GetString("crossover"));

        ManagerView.MutationRateText.text = $"Mutation Rate: {MutationRate * 100.0}%"; 
        ManagerView.CrossOverText.text = $"Crossover : {Crossover * 100.0}%";
        Debug.Log("Inicjuje...");
        for (int i = 0; i < NumOfBattles; i++)
        {
            CreateBattle();
        }
        
    }

    public void Update()
    {
        if (BattleFinished()) Train(); //Bitwy sie resetuja i zaczynają od początku kiedy wszystkie skąnczą (rzadko kiedy kończą )
    }

    void CreateBattle()
    {
        var battle = Instantiate(BattlePrefab);
        var view = Instantiate(ViewPrefab);
        battle.transform.SetParent(transform);
        view.transform.SetParent(MainView.transform);

        Battles.Add(battle.GetComponent<MLBattle>());
        Views.Add(view.GetComponent<MLBattleView>());

        Battles.Last().view = Views.Last();
        Battles.Last().agent = AgentPrefab;
        Battles.Last().enemy = EnemyPrefab;
        Battles.Last().BattleSpeed = BattleSpeed;
    }

    void Train()
    {
        //Inne rzeczy które potrzebujesz tutaj dobre miejsce 
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

    void UpdateWeights()//Tutaj implementujesz algorytmy kto po kim bierze wagi i jak 
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
            //Jedna metoda do crossover i mutation
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
