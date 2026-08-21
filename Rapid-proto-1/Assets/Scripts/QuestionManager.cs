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
            Debug.LogError(
                "NPC:ltä " + npc.name +
                " puuttuu NPCQuestion!"
            );

            return;
        }

        selectedAnswer = 0;

        // Asetetaan kysymykset nappeihin
        SetButtonText(answerButton1, currentNPC.question1);
        SetButtonText(answerButton2, currentNPC.question2);
        SetButtonText(answerButton3, currentNPC.question3);

        // Näytä kysymysnapit
        answerButton1.SetActive(true);
        answerButton2.SetActive(true);
        answerButton3.SetActive(true);

        guessButton.SetActive(true);

        passButton.SetActive(false);
        rejectButton.SetActive(false);
    }

    private void SetButtonText(GameObject buttonObject, string text)
    {
        if (buttonObject == null)
        {
            Debug.LogError("Question Button puuttuu!");
            return;
        }

        TMP_Text textComponent =
            buttonObject.GetComponentInChildren<TMP_Text>(true);

        if (textComponent == null)
        {
            Debug.LogError(
                "Buttonista " + buttonObject.name +
                " ei löytynyt TMP_Text-komponenttia!"
            );

            return;
        }

        textComponent.text = text;
    }

    public void Answer1()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 1;

        Debug.Log("KYSYMYS: " + currentNPC.question1);
        Debug.Log("VASTAUS: " + currentNPC.answer1);
    }

    public void Answer2()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 2;

        Debug.Log("KYSYMYS: " + currentNPC.question2);
        Debug.Log("VASTAUS: " + currentNPC.answer2);
    }

    public void Answer3()
    {
        if (currentNPC == null)
            return;

        selectedAnswer = 3;

        Debug.Log("KYSYMYS: " + currentNPC.question3);
        Debug.Log("VASTAUS: " + currentNPC.answer3);
    }

    public void Guess()
    {
        // Kysymysnapit pois
        answerButton1.SetActive(false);
        answerButton2.SetActive(false);
        answerButton3.SetActive(false);

        // ARVAA pois
        guessButton.SetActive(false);

        // PASS ja REJECT näkyviin
        passButton.SetActive(true);
        rejectButton.SetActive(true);

        Debug.Log("ARVAA painettu. Valittu kysymys: " + selectedAnswer);
    }

    public void Pass()
    {
        if (currentNPC == null)
            return;

        FinishNPC();
    }

    public void Reject()
    {
        if (currentNPC == null)
            return;

        FinishNPC();
    }

    private void FinishNPC()
    {
        passButton.SetActive(false);
        rejectButton.SetActive(false);

        // Napit näkyviin
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