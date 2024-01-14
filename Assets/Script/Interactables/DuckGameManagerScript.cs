using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckGame : MonoBehaviour
{
    public GameObject duckCanvas;
    public Button duckPrefab;
    public HygieneBar hygieneBar;
    public AudioSource duckAudio;
    public AudioClip duckAudioClip;

    private int remainingDucks;


    //start the duck game
    public void RunDuckGame()
    {

        // if the player left any ducks from the previous game and started it again, get rid of excess ducks
        // so they don't interfere with a new game
        ClearDucks(); 

        // create 4 ducks buttons on canvas and let them be clickable 
        for (int i = 0; i < 4; i++)
        {
            remainingDucks = 4;
            Button duckButton = Instantiate(duckPrefab, duckCanvas.transform);
            duckButton.onClick.AddListener(() => HandleDuckClick(duckButton));
            SetDuckRandomPosition(duckButton);
        }
    }

    // set the ducks at a random position between these ranges in the canvas 
    private void SetDuckRandomPosition(Button duck)
    {
        RectTransform rectTransform = duck.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(-250, 250), Random.Range(-250, 250));
    }

    public void HandleDuckClick(Button duck)
    {
        
        duck.gameObject.SetActive(false); //if duck is clicked, hide it from canvas
        duckAudio.clip = duckAudioClip; //play audio
        duckAudio.Play();
        remainingDucks--; //decrease the ducks 
       

        if (remainingDucks == 0) //if all 4 ducks have been clicked
        {
            duckCanvas.SetActive(false);

            if (PlayerManager.currentHygieneHealth < 100)
            {
                int newValue = (int)hygieneBar.slider.value + 12;
                if (newValue > 100)
                {            
                    newValue = 100; //add 12 to the hygiene bar but if its more than 100 then set it to 100
                }

                hygieneBar.SetHealth(newValue);
                PlayerManager.currentHygieneHealth = newValue; //assign it to the hygieneBar and health so it appears correct on the UI canvas
                
            }
        }
    }

    // this is called before the start of each different game so it gets rid of any other ducks that were
    // on the canvas from a previous game so that there should be only 4 ducks at a time and no more 
    private void ClearDucks()
    {
        Button[] ducks = duckCanvas.GetComponentsInChildren<Button>();
        foreach (Button duck in ducks)
        {
            Destroy(duck.gameObject);
        }
    }
}
