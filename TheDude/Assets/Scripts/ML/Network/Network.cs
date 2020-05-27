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
                    //double r = rand.NextDouble();
                    //if (mutationRate > r)
                    //{
                    //    synapse.Weight = rand.NextDouble();
                    //    //synapse.Weight += synapse.Weight * (double)UnityEngine.Random.Range(-0.05f, 0.05f);
                    //}
                    synapse.Weight += synapse.Weight * (double)UnityEngine.Random.Range(-0.05f, 0.05f);
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
        int cross = 2 * (int)Math.Round(tempVlaue,0);
        
        Debug.Log($"Cross:{crossoverPercent} | Mutation:{mutationRate}  | {cross}");

        //if (cross > dad.Count - 18)
        //    cross = dad.Count - 18;

        //Create array with index
        int[] array = new int[dad.Count];
        //int[] array = new int[cross];
        for (int j = 0; j < dad.Count; j++) //cross <- dad.Count
            array[j] = j;

        //Shuffle
        for (int j = 0; j < array.Length; j++)
        {
            int tmp = array[j];
            int r = UnityEngine.Random.Range(j, array.Length);
            array[j] = array[r];
            array[r] = tmp;
        }

        List<double> son = dad;
        for (int i = 0; i < cross; i++)
        {
            son[array[i]] = mom[array[i]];
            //son[array[i+1]] = mom[array[i+1]];
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

