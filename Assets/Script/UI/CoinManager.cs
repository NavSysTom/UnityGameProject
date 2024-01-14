using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    public static int coins = 0;
    public static CoinManager Instance;

    void Start()
    {
        UpdateCoinUI(); // update the coin counter
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    // Function to add coins
    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI(); //increase the amount of coins and make sure it saves the UI 
    }

    // Function to reduce coins
    public void ReduceCoins(int amount)
    {
        coins -= amount;
        if (coins < 0)
            coins = 0;
        UpdateCoinUI(); // get rid of coins from the counter and if the coins are less than 0, it is 0, you can't go into negatives
    }

    // Update the UI with the current coin count
    void UpdateCoinUI()
    {
        coinText.text = coins.ToString(); //update the text of the coin to display whatever the coin amount is 
    }
}