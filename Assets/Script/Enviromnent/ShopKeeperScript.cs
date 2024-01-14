using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperScript : MonoBehaviour
{
    private bool canInteract = false;
    private bool gameRun = false;
    public GameObject shopMenuCanvas;
    public int itemCost;
    public int healthRecovered;
    public FoodBar foodbar;
    public AudioSource audioSource;
    public AudioClip clip;
    // OnTriggerEnter is called when another Collider enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            // Display a message or change the object's appearance to indicate it can be interacted with.
        }
    }


    // OnTriggerExit is called when another Collider exits the trigger zone.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            // Remove the message or change the object's appearance to indicate it's no longer interactable.
        }
    }
    public void PurchaseItem()
    {
        // if the coins are more then what the item cost is assigned to
        // get rid of the coins from the coinManager
        // play audio of bood being bought, increase the health by the value assigned to the food
        // assign the health with now the increased food and set the slider value also so it matches
        // if not, can't buy the food 
        if (CoinManager.coins >= itemCost)
        {

            CoinManager.Instance.ReduceCoins(itemCost);
            Debug.Log("Item bought");
            audioSource.clip = clip; 
            audioSource.Play();
            
            if (PlayerManager.currentFoodHealth < 100)
            {
                int newValue = (int)foodbar.slider.value + healthRecovered;
                if (newValue > 100)
                {
                    newValue = 100;
                }

                foodbar.SetHealth(newValue);
                PlayerManager.currentFoodHealth = newValue;

            }


        }
        else
        {
            Debug.Log("Not enough coin");
        }
    }

    private void Update()
        // this allows for constant keeping if the canvas is turned on or not, if its off 
        // and the player can interact with it. it should turn it on, if its on 
        // it should turn it off and also when the player is out of range by walking out of the 
        // interaction range and still wants to close the tab, he can press E and it will still close it 
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (!gameRun)
            {
                Debug.Log("Should turn canvas on");
                shopMenuCanvas.SetActive(true);
                gameRun = true;
            }
            else
            {
                Debug.Log("Should turn canvas off");
                shopMenuCanvas.SetActive(false);
                gameRun = false;
            }
        }
        else if (!canInteract && Input.GetKeyDown(KeyCode.E)) // If not in trigger and pressing E
        {
            Debug.Log("Should turn canvas off");
            shopMenuCanvas.SetActive(false);
            gameRun = false;

        }
    }

}

