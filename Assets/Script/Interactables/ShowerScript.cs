using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowerScript : MonoBehaviour
{
    private bool canInteract = false;
    private bool gameRun = false;
    public DuckGame DuckManager;
    public GameObject duckCanvas;

    // OnTriggerEnter is called when another Collider enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            // if the player gets close to the shower, player can interact with it so set it true
        }
    }





    // OnTriggerExit is called when another Collider exits the trigger zone.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            // if out of area, can't interact with it 
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (!gameRun)
            {
                duckCanvas.SetActive(true);
                DuckManager.RunDuckGame();
                gameRun = true; //run the duckGame when presses E and if the game isn't running
            }
            else
            {
                duckCanvas.SetActive(false);
                gameRun = false; //if game is running,and player presses E, get rid of game and canvas
            }
        }
        else if (!canInteract && Input.GetKeyDown(KeyCode.E)) 
        {
            duckCanvas.SetActive(false);
            gameRun = false; //if the player is in the duck Game but out of the range of the trigger
            // the player should still be able to close the game so he isn't stuck in it 
           
        }
    }
}

