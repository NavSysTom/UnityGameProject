using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonStateManager : MonoBehaviour
{
    private static bool[] buttonPressed = new bool[6];
    private static bool[] imageStates = new bool[6];
    public static float sliderValue = 0f;

    //a buttonState manager for the Games Menu
    // when a button is clicked, it should remained clicked even between scene transitions
    public static bool IsButtonPressed(int buttonIndex)
    {
        return buttonPressed[buttonIndex];
    }

    //set if the button is pressed or not 
    public static void SetButtonPressed(int buttonIndex, bool isTickImage)
    {
        buttonPressed[buttonIndex] = true;
        imageStates[buttonIndex] = isTickImage;
    }

    //get an image
    //in the final product of the game, this was not used, its implementation was not working as intended
    //it was meant to replace the coin image with a tick image however it would turn all the coins into ticks on scene swaps
    public static bool GetImageState(int buttonIndex)
    {
        return imageStates[buttonIndex];
    }

    public static void ResetButtonStates()
    {
        //reset all the buttons, all the images and set the progress slider to 0 
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            buttonPressed[i] = false;
            imageStates[i] = false;
        }
        sliderValue = 0f;
    }
}