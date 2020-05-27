using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

static class Functions 
{
    public static double InputSumFunction(List<Synapse> Inputs, double bias = 0)
    {
        double input = 0;
        foreach (Synapse syn in Inputs)
            input += syn.GetOutput();
        input += bias;
        return input;
    }

    public static double SigmoidFunction(double input)
    {
        return 1 / (1 + Math.Exp(-input));
    }

    public static void SaveNetwork(List<double> weights)
    {
        List<string> dataToSave = new List<string>();

        foreach (var item in weights)
        {
            dataToSave.Add(item.ToString());
        }

        File.WriteAllLines(Application.dataPath + "\\network.txt", dataToSave);
    }

    public static List<double> LoadNetwork()
    {
        string[] data = File.ReadAllLines(Application.dataPath + "\\network.txt");

        List<double> network = new List<double>();
        for (int i = 0; i < data.Length; i++)
        {
            network.Add(Convert.ToDouble(data[i]));
        }

        return network;
    }
}
