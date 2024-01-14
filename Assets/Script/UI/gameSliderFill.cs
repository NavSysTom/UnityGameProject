using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class gameSliderFill : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component
    public int sliderIncrease;
    public int coinCost;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI percentageText;
    public Button[] buttons;
    public CoinManager coinManager;
    public GameObject gameMakeScreen;
    public GameObject tickImage;
    public GameObject costImage;
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    { 
        // get the sliderValue of the ButtonStateManager which should be 0 at the beginning and set it to that
        slider.value = ButtonStateManager.sliderValue;
        UpdateFillColor();
        UpdatePercentageText();
        //else update the fill and percentage text on what it was saved when scene swaps were made

        for (int i = 0; i < buttons.Length; i++)
        {
            if (ButtonStateManager.IsButtonPressed(i))
            {
                DisableButton(i);
               //check if the button was clicked and if it was then disable the button feature
            }
        }
    }


    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            gameMakeScreen.SetActive(false); //if E is pressed on the canvas, get rid of it 
        }
    }

    public void IncrementSliderValue(int buttonIndex)
    {
        if (CoinManager.coins >= coinCost)
            //if you have more coins then the cost of the button
            //increase the slider and decerase the coins by the amount 
        {
            slider.value += sliderIncrease;
            CoinManager.Instance.ReduceCoins(coinCost);
            

            //if the slider is at 100, which is the maxValue set, then we load the Game Win Scene 
            // and then it also resets all the buttons and the slider in the gameManager for the next game
            if (slider.value >= slider.maxValue)
            {
                Debug.Log("Slider value reached maximum!");
                ButtonStateManager.ResetButtonStates();
                SceneManager.LoadScene("Game Win");
            }

            //update the FillColor according to the amount on the slider and update the next
            UpdateFillColor();
            UpdatePercentageText();
            DisableButton(buttonIndex); //the button should not be clicked now so disable it 
            audioSource.clip = clip;
            audioSource.Play(); //play audio


            ButtonStateManager.SetButtonPressed(buttonIndex, true);
            ButtonStateManager.sliderValue = slider.value; //the slider value should not be increased and displayed in the UI


        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    private void UpdateFillColor()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue); //update the Fill content of the UI slider based and display it on the gradient
        
    }

    private void UpdatePercentageText()
    {
        float percentage = slider.value / slider.maxValue * 100;
        percentageText.text = $"{percentage.ToString("F0")}%"; //get the text and display it next to the slider so that you can see the score progression
    }

    private void DisableButton(int buttonIndex)
    {
        //gets rid of the button clickability however it keeps the child Text Image so you can see 
        //what the text on the previous button was 
        Image buttonImage = buttons[buttonIndex].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.enabled = false;
        }

        TextMeshProUGUI buttonText = buttons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.enabled = true;
        }

        buttons[buttonIndex].interactable = false;
    }
   
}

