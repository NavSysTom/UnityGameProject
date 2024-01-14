using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject MenuUI;
    private bool isMenuActive = false;
    public AudioSource audio;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isMenuActive)
            {
                MenuUI.SetActive(true);
                isMenuActive = true;
                audio.clip = clip; 
                audio.Play(); // make the UI active and play an audio of the UI being pressed
            }
            else
            {
                MenuUI.SetActive(false);
                isMenuActive = false; //else disable it 
            }
        }
    }

    public void menuReturn()
    {
        Player.healthGiven = false;
        CoinManager.coins = 0;
        ButtonStateManager.ResetButtonStates();
        SceneManager.LoadScene("Main Menu"); //get all the statics and change them so that when the player goes from the game 
        // to the menu and then makes a new game, it should not keep any of the previous data recorded and make the new game 

    }

    public void quitGame()
    {
        Application.Quit(); //quit the game 
    }
}
