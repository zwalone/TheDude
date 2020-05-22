using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Neutral, Fire, Wind, Water, Earth }
public static class Types
{
    static double[][] AttackTable = new double[][] {
        new double[] { 1.0, 1.0, 1.0, 1.0, 1.0 },
        new double[] { 1.0, 0.5, 2.0, 0.3, 1.0 },
        new double[] { 1.0, 0.3, 0.5, 1.0, 2.0 },
        new double[] { 1.0, 2.0, 1.0, 0.5, 0.3 },
        new double[] { 1.0, 1.0, 0.3, 2.0, 0.5 }};
    public static double GetAttackTypeModifire(Type first, Type second)
    {
        return AttackTable[(int)first][(int)second];
    }

    public static double SameType(Type first, Type second)
    {
        if (first == second) return 1.5;
        else return 1.0;

    }
}
