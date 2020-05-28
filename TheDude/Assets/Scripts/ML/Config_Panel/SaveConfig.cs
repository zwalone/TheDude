using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveConfig : MonoBehaviour
{
    public Text mutationText;

    public Text crossoverText;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void SaveConfigToPref()
    {
        PlayerPrefs.SetString("mutationRate", mutationText.text);
        PlayerPrefs.SetString("crossover", crossoverText.text);
        Debug.Log("Saved config mutation  " +  mutationText.text + "  crossover  " + crossoverText.text  );
        SceneManager.LoadScene("ML_Battle");
    }
}
