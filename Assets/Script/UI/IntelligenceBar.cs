using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntelligenceBar: MonoBehaviour
{
    //same code as the foodbar and the hygiene bar, updates the health based on the damage it received 
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
