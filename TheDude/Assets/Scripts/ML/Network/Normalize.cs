using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Normalize
{ 
    static double FindMaxValue(double[][] lista, int k)
    {
        double max = lista[0][k];
        for (int i = 0; i < lista.Length; i++)
        {
            if (max < lista[i][k])
            {
                max = lista[i][k];
            }
        }
        return max;
    }

    static double FindMinValue(double[][] lista, int k)
    {
        double min = lista[0][k];
        for (int i = 0; i < lista.Length; i++)
        {
            if (min > lista[i][k])
            {
                min = lista[i][k];
            }
        }
        return min;
    }

    static double NormalizeData(double value, double min, double max, double nmax, double nmin)
    {
        double x = ((value - min) / (max - min)) * (nmax - nmin);
        return x;
    }

    //Normalize 1 column
    static double[][] DoNormalize(double[][] tab, int column, double nmax, double nmin)
    {
        double max = FindMaxValue(tab, column);
        double min = FindMinValue(tab, column);
        double[][] temp = tab;

        for (int i = 0; i < tab.Length; i++)
        {
            temp[i][column] = NormalizeData(temp[i][column], min, max, nmax, nmin);
        }
        return tab;
    }
}
