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

    public static void SaveNetwork(List<double> network)
    {
        List<string> dataToSave = new List<string>();

        foreach (var item in network)
        {
            dataToSave.Add(item.ToString());
        }

        File.WriteAllLines(Application.dataPath, dataToSave);
    }
}
