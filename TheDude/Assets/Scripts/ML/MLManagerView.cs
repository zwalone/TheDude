using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MLManagerView : MonoBehaviour
{
    public Text GenerationText;
    public Text HighestScoreText;
    public Text MutationRateText;
    public Text CrossOverText;

    //Do some stuff update etc

    public void ChangeGeneration(int gen)
    {
        GenerationText.text = $"GEN: {gen}";
    }

}
