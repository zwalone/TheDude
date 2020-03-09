using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    private List<int> modifires;
    [SerializeField]
    private int _maxValue;
    public int maxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            _maxValue += maxValue;
        }
    }
    [SerializeField]
    private int _value;
    public int value
    {
        get
        {
            // add all modifires and return 
            return _value;
        }
        set
        {
            //check max value and floor the result
            _value += value;
        }
    }


    public void AddModifire(int mod)
    {
        // list add modifires and count other parameters like maximum value, multiplication and so on 
    }

     public void RemoveModifire(int mod)
    {
        // list remove modifires and count other parameters
    }

}
