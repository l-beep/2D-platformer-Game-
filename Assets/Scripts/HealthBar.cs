using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slide;
    void Start()
    {
        Slide.maxValue = 10;
        Slide.minValue = 0;

        Slide.value = 10;
    }

    public void Damage()
    {
        Slide.value -= 2;
        if(Slide.value <= 0)
        {
            Debug.Log("Die");
        }
    }
}
