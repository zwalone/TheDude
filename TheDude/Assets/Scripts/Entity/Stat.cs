using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    private List<int> modifires;

    [SerializeField]
    private int val;
    public int Val
    {
        get {return val;}
        set
        {
            if(val + value <0) val = 0;
            else val += value;
        }
    }

    public int GetModifires()
    {
        int tmp = val;
        if(modifires != null)
        {
            foreach (int item in modifires)
                tmp += item;
        }
        return tmp;
    }
    public void AddModifire(int mod)
    {
        if(modifires == null)
            modifires = new List<int>();
        modifires.Add(mod);
    }

     public void RemoveModifire(int mod)
    {
        modifires.Remove(mod);
    }

}
