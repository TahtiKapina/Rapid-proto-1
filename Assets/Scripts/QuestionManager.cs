using UnityEngine;
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

    private NPCQuestion currentNPC;
    private int selectedAnswer = 0;

    public Score scoreManager;

    private void Start()
    {
        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    public void SetNPC(GameObject npc)
    {
        currentNPC = npc.GetComponent<NPCQuestion>();

        if (currentNPC == null)
        {
            Debug.LogError("NPC:ltä puuttuu NPCQuestion!");
            return;
        }

        selectedAnswer = 0;

        SetButtonText(answerButton1, currentNPC.question1);
        SetButtonText(answerButton2, currentNPC.question2);
        SetButtonText(answerButton3, currentNPC.question3);

        answerButton1.SetActive(true);
        answerButton2.SetActive(true);
        answerButton3.SetActive(true);

        guessButton.SetActive(true);

        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    private void SetButtonText(GameObject buttonObject, string text)
    {
        TMP_Text textComponent =
            buttonObject.GetComponentInChildren<TMP_Text>(true);

        if (textComponent != null)
        {
            textComponent.text = text;
        }
    }

    public void Answer1()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 1;
        SetButtonText(answerButton1, currentNPC.answer1);

        Debug.Log("Kysymys: " + currentNPC.question1);
        Debug.Log("Vastaus: " + currentNPC.answer1);
    }

    public void Answer2()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 2;
        SetButtonText(answerButton2, currentNPC.answer2);

        Debug.Log("Kysymys: " + currentNPC.question2);
        Debug.Log("Vastaus: " + currentNPC.answer2);
    }

    public void Answer3()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 3;
        SetButtonText(answerButton3, currentNPC.answer3);

        Debug.Log("Kysymys: " + currentNPC.question3);
        Debug.Log("Vastaus: " + currentNPC.answer3);
    }

    public void Guess()
    {
        answerButton1.SetActive(false);
        answerButton2.SetActive(false);
        answerButton3.SetActive(false);

        guessButton.SetActive(false);

        passButton.SetActive(true);
        rejectButton.SetActive(true);

        Debug.Log("ARVAA painettu. Valittu kysymys: " + selectedAnswer);
    }

    public void Pass()
    {
        if (currentNPC == null)
            return;

        CheckYokaiStatus(playerPassed: true);

        FinishNPC();
    }

    public void Reject()
    {
        if (currentNPC == null)
            return;

        CheckYokaiStatus(playerPassed: false);

        FinishNPC();
    }

    private void CheckYokaiStatus(bool playerPassed)
    {
        GhostData data = currentNPC.GetComponent<GhostData>();

        if (data != null)
        {
            bool isYokai = data.IsYokai();

            if (playerPassed)
            {
                if (isYokai)
                {
                    Debug.Log("Väärin! Päästit Yokain läpi!");
                    scoreManager.addScore();
                }
                else
                {
                    Debug.Log("Oikein! Päästit tavallisen kummituksen läpi.");
                }
            }
            else // player chose Reject
            {
                if (isYokai)
                {
                    Debug.Log("Oikein! Hylkäsit Yokain.");
                }
                else
                {
                    Debug.Log("Väärin! Hylkäsit tavallisen kummituksen!");
                    scoreManager.addScore();
                }
            }
        }
        else
        {
            Debug.LogWarning("NPC:ltä puuttuu GhostData-skripti!");
        }
    }

    private void FinishNPC()
    {
        passButton.SetActive(false);
        rejectButton.SetActive(false);

        answerButton1.SetActive(true);
        answerButton2.SetActive(true);
        answerButton3.SetActive(true);

        guessButton.SetActive(true);

        if (currentNPC != null)
        {
            Destroy(currentNPC.gameObject);
            currentNPC = null;
        }
    }
}