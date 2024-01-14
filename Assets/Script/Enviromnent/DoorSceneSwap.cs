using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneSwap : MonoBehaviour
{
  
    private void Start()
    {
        //when going between the door in the house to the shop, find player and get all his information
        
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.foodBar.SetHealth(PlayerManager.currentFoodHealth);
        player.hygieneBar.SetHealth(PlayerManager.currentHygieneHealth);
        player.intelligenceBar.SetHealth(PlayerManager.currentIntelligenceHealth);

        Debug.Log("Loaded Door scene");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.SavePlayerData(); // Save the player's data
            }// load the ShopScene
            SceneManager.LoadScene("ShopScene");

        }
    }
}
