using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Level on map
    private int _level;
    public int level
    {
        get
        {
            return _level;
        }
        set
        {
            _level += value;
        }
    }

    //Current ''dot'' in path on map
    private int _pathlevel;
    public int pathlevel
    {
        get
        {
            return _pathlevel;
        }
        set
        {
            _pathlevel += value;
        }
    }

    //=====SINGELTON====//
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        //Create Singelton
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //Load Scene by name
    public void ChangeScene(string scenename)
    {
        Debug.Log("Scene Load :" + scenename);
        SceneManager.LoadScene(scenename);
    }
}
