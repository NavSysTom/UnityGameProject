using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuScript : MonoBehaviour
{
    private void Start()
    {
        // get Player and all its information and assign it 
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.foodBar.SetHealth(PlayerManager.currentFoodHealth);
        player.hygieneBar.SetHealth(PlayerManager.currentHygieneHealth);
        player.intelligenceBar.SetHealth(PlayerManager.currentIntelligenceHealth);


      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collisions checks the tag and it is player save it and load the scene else do nothing 
        if (collision.CompareTag("Player"))
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.SavePlayerData(); // Save the player's data
                
            }
            //load the House Scene
            SceneManager.LoadScene("HouseScene");
        }
    }
    
}



