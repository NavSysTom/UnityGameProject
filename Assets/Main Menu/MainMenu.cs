using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    //this mainMenu is used for both the mainMenu and the GameOver Screen
    public AudioSource audio;

    public void playButton()
    {
        audio.Play(); 
    }
    public void PlayGame()
    {
        Player.healthGiven = false;
        CoinManager.coins = 0;
        ButtonStateManager.ResetButtonStates();
        SceneManager.LoadScene("HouseScene");
        //set all the statics to 0 or false to reset them and then load the house Scene to begin the game
    }

    public void loadOptions()
    {
        //load option scene
        SceneManager.LoadScene("Options");
    }

    public void PlayAgain()
    {
        Player.healthGiven = false;
        CoinManager.coins = 0;
        ButtonStateManager.ResetButtonStates();
        SceneManager.LoadScene("HouseScene");
        //set all the statics to 0 or false to reset them and then load the house Scene to begin the game
    }

    public void QuitGame()
    {
        //quit game
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
