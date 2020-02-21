using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //TODO Mana or Energy costs 

    [SerializeField]
    private int _hp;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp += value;
        }
    }

    [SerializeField]
    private int _maxhp;
    public int maxhp
    {
        get
        {
            return _maxhp;
        }
        set
        {
            _maxhp += value;
        }
    }

    //Base dmg
    [SerializeField]
    private int _atk;
    public int atk
    {
        get
        {
            return _atk;
        }
        set
        {
            _atk += value;
        }
    }

    //Who will first attack in battle
    [SerializeField]
    private int _dex;
    public int dex
    {
        get
        {
            return _dex;
        }
        set
        {
            _dex += value;
        }
    }
}
