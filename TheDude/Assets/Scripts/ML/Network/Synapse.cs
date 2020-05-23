using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Linq;
using System.IO;
using System;

public class Synapse 
{
    
    static System.Random tmp = new System.Random();
    internal Neuron FromNeuron, ToNeuron;
    public double Weight { get; set; }
    public double OutputValue { get; set; }

    public Synapse(Neuron fromneuron, Neuron toneuron)
    {
        FromNeuron = fromneuron; ToNeuron = toneuron;
        Weight = tmp.NextDouble() -0.5;
        //Debug.Log($"Weight {Weight}");
    }

    public Synapse(Neuron toneuron, double output) // synapsa połączona z neuronami wejściowymi
    {
        ToNeuron = toneuron; OutputValue = output;
        Weight = 1;
    }

    public double GetOutput()
    {
        if (FromNeuron == null) return OutputValue;
        return FromNeuron.OutputValue * Weight;
    }

    public void UpdateWeight(double delta)
    {
        Weight += delta;
    }
}
