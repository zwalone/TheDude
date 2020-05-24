using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Network 
{
    internal List<Layer> Layers;
    internal float LearningRate = 5f;
    static System.Random rand = new System.Random();

    public Network(int inputneuronscount, int hiddenlayerscount, int hiddenneuronscount, int outputneuronscount)
    {
        
        Layers = new List<Layer>();
        AddFirstLayer(inputneuronscount);
        for (int i = 0; i < hiddenlayerscount; i++)
            AddNextLayer(new Layer(hiddenneuronscount));
        AddNextLayer(new Layer(outputneuronscount));
        //Debug.Log("Stworzona sieć");
    }

    private void AddFirstLayer(int inputneuronscount)
    {
        Layer inputlayer = new Layer(inputneuronscount);
        foreach (Neuron neuron in inputlayer.Neurons)
            neuron.AddInputSynapse(0);
        Layers.Add(inputlayer);
    }

    public void AddNextLayer(Layer newlayer)
    {
        Layer lastlayer = Layers[Layers.Count - 1];
        lastlayer.ConnectLayers(newlayer);
        Layers.Add(newlayer);
    }

    public void PushInputValues(double[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
            Layers[0].Neurons[i].PushValueOnInput(inputs[i]);
    }

    public List<double> GetOutput()
    {
        List<double> output = new List<double>();
        for (int i = 0; i < Layers.Count; i++)
            Layers[i].CalculateOutputOnLayer();
        foreach (Neuron neuron in Layers[Layers.Count - 1].Neurons)
            output.Add(neuron.OutputValue);

        //Debug.Log($" Pobrane wartości !!++++!+!+!+!+");
        return output;
    }

    //Change Weights with mutations calculate propability foreach all synapse and change to random weights
        //is possible with other form mutation like swap weights, invertions weight, scramble (permutations :) weights) 
    public void ChangeWeights(double mutationRate)
    {
        foreach (Layer layer in Layers)
        {
            foreach (Neuron neuron in layer.Neurons)
            {
                foreach (Synapse synapse in neuron.Inputs)
                {
                    if (mutationRate < rand.NextDouble())
                    {
                        synapse.Weight = rand.NextDouble() - 0.5;
                    }
                    //double percent = (double)UnityEngine.Random.Range(-LearningRate, LearningRate);
                    //double delta = synapse.Weight * (percent / 100);
                    //Debug.Log($"Synapse Weight : {synapse.Weight} Delta : {delta}");
                    //synapse.Weight += delta;
                }
            }
        }
    }

    //Method to add Weights to clone 
    public void PushWeights(List<double> data)
    {
        int i = 0;
        foreach (Layer layer in Layers)
        {
            foreach (Neuron neuron in layer.Neurons)
            {
                foreach (Synapse synapse in neuron.Inputs)
                {
                    synapse.Weight = data[i];
                    i++;
                }
            }
        }
    }

    //Crossover parents weights crossover max 0.5
    public void PushWeightsFromParents(List<double> dad , List<double> mom, double crossoverPercent = 0.05 , double mutationRate = 0.01)
    {
        double tempVlaue = (double)dad.Count * crossoverPercent;
        int cross = (int)Math.Round(tempVlaue,0);

        Debug.Log($"Percent : {crossoverPercent} | Count Synapse :{dad.Count}  | How much to change {cross}");

        List<double> son = dad;
        for (int i = 0; i < cross; i++)
        {
            int temp = rand.Next(0, dad.Count);
            son[temp] = mom[temp];
            son[temp + 1] = mom[temp + 1];
        }

        PushWeights(son);
        ChangeWeights(mutationRate);

    }

    //return list weights ,,winnig'' object
    public List<double> GetWeights()
    {
        List<double> weightsList = new List<double>();
        foreach (Layer layer in Layers)
        {
            foreach (Neuron neuron in layer.Neurons)
            {
                foreach (Synapse synapse in neuron.Inputs)
                {
                    weightsList.Add(synapse.Weight);
                }
            }
        }

        return weightsList;
    }

}

