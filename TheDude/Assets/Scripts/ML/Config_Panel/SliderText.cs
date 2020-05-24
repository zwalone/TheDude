using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderText : MonoBehaviour
{
    Text sliderText;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        sliderText = this.GetComponent<Text>();
        slider = this.GetComponentInParent<Slider>();
        TextUpdate();
    }

    public void TextUpdate()
    {
        sliderText.text = Math.Round(slider.value, 2).ToString();
    }
}
