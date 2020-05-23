using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
