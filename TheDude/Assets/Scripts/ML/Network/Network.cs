using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network 
{
    internal List<Layer> Layers;
    internal float LearningRate = 5f;

    public Network(int inputneuronscount, int hiddenlayerscount, int hiddenneuronscount, int outputneuronscount)
    {
        
        Layers = new List<Layer>();
        AddFirstLayer(inputneuronscount);
        for (int i = 0; i < hiddenlayerscount; i++)
            AddNextLayer(new Layer(hiddenneuronscount));
        AddNextLayer(new Layer(outputneuronscount));
        Debug.Log("Stworzona sieć");
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

        Debug.Log($" Pobrane wartości !!++++!+!+!+!+");
        return output;
    }

    //Change Weights with mutations here <--- After clone :)
    public void ChangeWeights()
    {
        foreach (Layer layer in Layers)
        {
            foreach (Neuron neuron in layer.Neurons)
            {
                foreach (Synapse synapse in neuron.Inputs)
                {
                    double percent = (double)UnityEngine.Random.Range(-LearningRate, LearningRate);
                    double delta = synapse.Weight * (percent / 100);
                    Debug.Log($"Synapse Weight : {synapse.Weight} Delta : {delta}");
                    synapse.Weight += delta;
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

