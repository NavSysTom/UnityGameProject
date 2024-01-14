using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient; //gradient from red,yellow and green so it changes colour depending on the amount of health you have 
    public Image fill;

    public void setMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = health; 

        fill.color = gradient.Evaluate(1f); //set the max health of the foodbar and value 
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //get the current health and set it to the slider and the fill colour 

       
    }
}
