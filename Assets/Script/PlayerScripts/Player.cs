using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public FoodBar foodBar;
    public HygieneBar hygieneBar;
    public IntelligenceBar intelligenceBar;

    //Time Interval for health 
    public float timeIntervalFood = 13.0f;
    public float timeIntervalHygiene = 16.0f;
    public float timeIntervalIntelligence = 18.0f;

    public static bool healthGiven = false; 


    void Start()
    {   
        /* This is to deal with an issue between Scenes
         * have a static boolean set to false, if the game starts this line gets called
         * it uses our PlayerManager statics to give them 100 health on everything, set it on our foodBar UI aswell so the UI fill bar is full
         * set it to true now so that when the game is still active and playing and when the Player goes from Shop Scene to House Scene or vice versa it will keep the keep the accurate health 
         *
         */
        if (!Player.healthGiven)
        {
            
            PlayerManager.currentFoodHealth = 100;
            PlayerManager.currentHygieneHealth = 100;
            PlayerManager.currentIntelligenceHealth = 100;

            foodBar.setMaxHealth(100);
            hygieneBar.setMaxHealth(100);
            intelligenceBar.setMaxHealth(100);
            foodBar.SetHealth(PlayerManager.currentFoodHealth);
            hygieneBar.SetHealth(PlayerManager.currentHygieneHealth);
            intelligenceBar.SetHealth(PlayerManager.currentIntelligenceHealth);

            Player.healthGiven = true;

            PlayerPrefs.SetInt("FoodHealth", 100);
            PlayerPrefs.SetInt("HygieneHealth", 100);
            PlayerPrefs.SetInt("Intelligence", 100); //PlayerPrefs to save our data between scenes 
        }
        LoadPlayerData(); //otherwise load the given player data

        // Start the timer for health decay
        // This will be our health bar system going down 
        InvokeRepeating("AutoDecrementFood", 15f, timeIntervalFood);
        InvokeRepeating("AutoDecrementHygiene", 18f, timeIntervalHygiene);
        InvokeRepeating("AutoDecrementIntelligence", 20f, timeIntervalIntelligence);
        
    }

    public void SavePlayerData()
    {
        // Save health data using PlayerPrefs when transitioning between scenes
        PlayerPrefs.SetInt("FoodHealth", PlayerManager.currentFoodHealth);
        PlayerPrefs.SetInt("HygieneHealth", PlayerManager.currentHygieneHealth);
        PlayerPrefs.SetInt("Intelligence", PlayerManager.currentIntelligenceHealth);
    }

    public void LoadPlayerData()
    {
        //Load the Data to the Players Health 
        if (PlayerPrefs.HasKey("FoodHealth"))
        {
            PlayerManager.currentFoodHealth = PlayerPrefs.GetInt("FoodHealth");
            foodBar.SetHealth(PlayerManager.currentFoodHealth);
        }
        if (PlayerPrefs.HasKey("HygieneHealth"))
        {
            PlayerManager.currentHygieneHealth = PlayerPrefs.GetInt("HygieneHealth");
            hygieneBar.SetHealth(PlayerManager.currentHygieneHealth);
        }
        if (PlayerPrefs.HasKey("Intelligence"))
        {
            PlayerManager.currentIntelligenceHealth = PlayerPrefs.GetInt("Intelligence");
            intelligenceBar.SetHealth(PlayerManager.currentIntelligenceHealth);
        }
    }

    

    void AutoDecrementFood()
    {
        takeFoodDamage(12); //take 12 damage of Food damage 
    }

    void AutoDecrementHygiene()
    {
        takeHygieneDamage(12);//take 12 damage of Hygiene damage 
    }

    void AutoDecrementIntelligence()
    {
        takeIntelligenceDamage(20);//take 20 damage of Intelligence damage 
    }

    //Taking Damage to each of the different food bars and when they exceed 0 it will go to the Game Over Scene
    public void takeFoodDamage(int damage)
    {
        if (PlayerManager.currentFoodHealth > 0)
        {
            PlayerManager.currentFoodHealth -= damage;
            foodBar.SetHealth(PlayerManager.currentFoodHealth);

            if (PlayerManager.currentFoodHealth <= 0)
            {
                
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    public void takeHygieneDamage(int damage)
    {
        if (PlayerManager.currentHygieneHealth > 0)
        {
            PlayerManager.currentHygieneHealth -= damage;
            hygieneBar.SetHealth(PlayerManager.currentHygieneHealth);

            if (PlayerManager.currentHygieneHealth <= 0)
            {
                
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    public void takeIntelligenceDamage(int damage)
    {
        if (PlayerManager.currentIntelligenceHealth > 0)
        {
            PlayerManager.currentIntelligenceHealth -= damage;
            intelligenceBar.SetHealth(PlayerManager.currentIntelligenceHealth);

            if (PlayerManager.currentIntelligenceHealth <= 0)
            {
               
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}

