using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DesktopScript : MonoBehaviour
{
    private bool canInteract = false;
    public QuestionManager QuestionManager;
    public GameObject optionsMenu;
    public GameObject makeGameMenuCanvas;
    private bool menuActive = false;

    // OnTriggerEnter is called when another Collider enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            // if the player is in the area, the boolean to interact with the desktop becomes true
        }
    }





    // OnTriggerExit is called when another Collider exits the trigger zone.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E)) //if player can interact and presses E
        {
            menuActive = !menuActive;  // menu state

            if (menuActive)
            {
                optionsMenu.gameObject.SetActive(true); //show optionMenu when its pressed
            }
            else
            {
                optionsMenu.gameObject.SetActive(false); //else if E is pressed again, disable it 
               
            }
        }
        else if (!canInteract && Input.GetKeyDown(KeyCode.E)) // close it when out of range but player presses E so hes not stuck
        {
            optionsMenu.gameObject.SetActive(false);
            menuActive = false;
            
        }
    }


    public void gameStart()
    {
        //this gets the QuestionManager to show the random questions and hide the optionMenu 
        QuestionManager.ShowRandomQuestion();    
        optionsMenu.gameObject.SetActive(false);
    }


    public void makeGameMenu()
    {
        //get rid of OptionMenu canvas and make the makeGameCanvas appear so the user can interact with that one instead 
        //gameStart and makeGameMenu are operated using buttons to calls to these functions 
        optionsMenu.gameObject.SetActive(false);
        makeGameMenuCanvas.gameObject.SetActive(true);
    }
}

