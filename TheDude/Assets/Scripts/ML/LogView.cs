using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LogView : MonoBehaviour
{
    public List<string> TurnLogs;
    public Text CurrentLog;
    string _log = "Battle Just Started!!!\nLets Fight";
    string _stats;

    private int _head = 0;

    
    public void AddToLog(string content)
    {
        _log += content + "\n";
    }

    public void AddStats(string stats) 
    {
        _stats = stats;
    }

    public void NewTurn(int turn) 
    {
        TurnLogs.Add(_log);
        _log = $"Turn {turn}\n{_stats}\n";
    
    }
    public void Won()
    {
        TurnLogs.Add(_log);
        TurnLogs.Add($"Agent Wygrał");
    }
    public void Lost()
    {
        TurnLogs.Add(_log);
        TurnLogs.Add($"Agent Przegrał");
    }
    public void PreviousLog()
    {
        if (_head != 0) _head--;
        CurrentLog.text = TurnLogs[_head];
    }
    public void NextLog()
    {
        if (_head != TurnLogs.Count - 1) _head++;
        CurrentLog.text = TurnLogs[_head];
    }
}
