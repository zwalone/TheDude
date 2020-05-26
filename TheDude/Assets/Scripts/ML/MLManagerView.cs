using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MLManagerView : MonoBehaviour
{
    public Text GenerationText;
    public Text HighestScoreText;
    public Text MutationRateText;
    public Text CrossOverText;
    public Text WinsText;
    public Text WinningRateText;

    //Do some stuff update etc

    public void ChangeGeneration(int gen) => GenerationText.text = $"GEN: {gen}";
    public void ChangeWins(int win,int numOfFights) => WinsText.text = $"Wins: {win}/{numOfFights}";
    public void ChangeWinningRate(double rate) => WinningRateText.text = $"Winnin Rate: {rate}%";
    public void ChangeMutationRate(double mutationRate) => MutationRateText.text = $"Mutation Rate: {mutationRate * 100.0}%";
    public void ChangeCrossOver(double crossover) => CrossOverText.text = $"Crossover : {crossover * 100.0}%";


}
