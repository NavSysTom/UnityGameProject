using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
  
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main Menu"); //if any button is pressed, go back to the Main Menu
        }
    }
}
