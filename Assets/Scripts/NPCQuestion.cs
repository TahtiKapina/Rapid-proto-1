using UnityEngine;

public class NPCQuestion : MonoBehaviour
{
    [Header("Kysymykset")]

    [TextArea(2, 5)]
    public string question1 = "Kuka olet?";

    [TextArea(2, 5)]
    public string question2 = "Mitä täällä tapahtuu?";

    [TextArea(2, 5)]
    public string question3 = "Voitko auttaa minua?";



    private void Start()
    {
        QuestionManager questionManager =
            FindFirstObjectByType<QuestionManager>();

        if (questionManager != null)
        {
            questionManager.SetNPC(gameObject);
        }
        else
        {
            Debug.LogError("QuestionManageria ei löytynyt scenestä!");
        }
    }
}