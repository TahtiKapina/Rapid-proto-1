using UnityEngine;

public class NPCQuestion : MonoBehaviour
{
    [Header("Kysymykset")]

    [TextArea(2, 5)]
    public string question1 = "Kuka olet?";

    
    [TextArea(2, 5)]
    public string question3 = "Voitko auttaa minua?";
    [TextArea(2, 5)]
    public string question2 = "Mit‰ t‰‰ll‰ tapahtuu?";

    [Header("Vastaukset")]

    [TextArea(2, 5)]
    public string answer2 = "Kyl‰ss‰ on tapahtunut jotain outoa.";

     [TextArea(2, 5)]
    public string answer1 = "Olen t‰m‰n kyl‰n vartija.";

    [TextArea(2, 5)]
    public string answer3 = "Totta kai voin auttaa.";

    private void Start()
    {
        QuestionManager questionManager =
            FindFirstObjectByType<QuestionManager>();

        if (questionManager != null)
        {
            questionManager.SetNPC(gameObject);
        }
    }
}