using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    //Serialisable class to represent a question and its details
    // This is used to create many different questions using this same format
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
    public Sprite questionImage;
    
}

public class QuestionManager : MonoBehaviour
{
    public GameObject questionCanvas;
    private int correctAnswerIndex; // Index of the correct answer.
    public List<Question> questions = new List<Question>();
    public TextMeshProUGUI questionText; //questionText
    public Button[] answerButtons;
    public Image questionImage;
    public CoinManager coinManager;
    public AudioSource source;
    public AudioClip wrongClip;
    public AudioClip answerClip;

    public IntelligenceBar intelligenceBar;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            questionCanvas.SetActive(false); //if press E, get rid of the canvas
        }
    }

    
    public void ShowRandomQuestion()
    {
        if (questions.Count > 0)

        { //get a random question from the list of questions and set it 
            int randomIndex = Random.Range(0, questions.Count);
            Question randomQuestion = questions[randomIndex];

            // set the text and the correct answer index based on the question on which it received
            questionText.text = randomQuestion.questionText;
            correctAnswerIndex = randomQuestion.correctAnswerIndex;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomQuestion.answers[i];
            } // this gets the Text from the children Component of the answers and assigns it to the buttons so the text is in the buttons of the answers

            // Set the question image if needed.
            questionImage.sprite = randomQuestion.questionImage;
            questionCanvas.SetActive(true); //set the canvas to true
        }
        
    }

    public void AnswerQuestion(int selectedAnswerIndex)
    {
        if (selectedAnswerIndex == correctAnswerIndex) //if the answer clicked is the correct one
        {


            if (PlayerManager.currentIntelligenceHealth < 100)
            {
                int newValue = (int)intelligenceBar.slider.value + 7;
                if (newValue > 100)
                {
                    newValue = 100; 
                }

                intelligenceBar.SetHealth(newValue);
                PlayerManager.currentIntelligenceHealth = newValue; //add 7 to the intelligence health and bar,update on the UI 
            }

            source.clip = answerClip;
            source.Play();
            coinManager.AddCoins(5); //play the correct audio and also add 5 coins to the coin Manager 

            Debug.Log(PlayerManager.currentIntelligenceHealth);

            questionCanvas.SetActive(false);
        }
        else
        {
            //else if you click the wrong button 
            // play wrong audio noise, decerase the intelligence by 5
            // update Slider and static intelligence health 
            // if the current health goes below 0, game Over
            source.clip = wrongClip;
            source.Play();
            intelligenceBar.SetHealth((int)intelligenceBar.slider.value - 5);
            PlayerManager.currentIntelligenceHealth = PlayerManager.currentIntelligenceHealth - 5;
            Debug.Log(PlayerManager.currentIntelligenceHealth);

            if (PlayerManager.currentIntelligenceHealth <= 0)
            {
                SceneManager.LoadScene("Game Over");

            }
        }
    }
}
