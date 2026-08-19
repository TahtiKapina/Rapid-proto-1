using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [Header("Question Buttons")]
    public GameObject answerButton1;
    public GameObject answerButton2;
    public GameObject answerButton3;

    [Header("Guess Button")]
    public GameObject guessButton;

    [Header("Pass / Reject")]
    public GameObject passButton;
    public GameObject rejectButton;

    private int selectedAnswer = 0;

    // Oikea kysymys
    private int correctAnswer = 1;

    private void Start()
    {
        // Aseta kysymykset suoraan nappeihin
        SetButtonText(answerButton1, "Kuka olet?");
        SetButtonText(answerButton2, "Mitä täällä tapahtuu?");
        SetButtonText(answerButton3, "Voitko auttaa minua?");

        // Piilota Pass ja Reject alussa
        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    // Laittaa tekstin Buttonin TMP-tekstiin
    private void SetButtonText(GameObject buttonObject, string text)
    {
        TMP_Text buttonText = buttonObject.GetComponentInChildren<TMP_Text>();

        if (buttonText != null)
        {
            buttonText.text = text;
        }
        else
        {
            Debug.LogError("Buttonista ei löytynyt TMP_Text-komponenttia!");
        }
    }

    // Kysymysnapit kutsuvat tätä
    public void Answer(int question)
    {
        selectedAnswer = question;

        Debug.Log("Valittu kysymys: " + selectedAnswer);
    }

    // ARVAA-nappi
    public void Guess()
    {
        // Piilota kysymysnapit
        answerButton1.SetActive(false);
        answerButton2.SetActive(false);
        answerButton3.SetActive(false);

        // Piilota ARVAA-nappi
        guessButton.SetActive(false);

        // Näytä PASS ja REJECT
        passButton.SetActive(true);
        rejectButton.SetActive(true);

        Debug.Log("Valittu kysymys: " + selectedAnswer);
    }

    // PASS
    public void Pass()
    {
        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("OIKEIN! PASS");
        }
        else
        {
            Debug.Log("VÄÄRIN!");
        }

        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    // REJECT
    public void Reject()
    {
        if (selectedAnswer != correctAnswer)
        {
            Debug.Log("OIKEIN! REJECT");
        }
        else
        {
            Debug.Log("VÄÄRIN!");
        }

        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }
}