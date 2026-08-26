using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject fail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void addScore()
    {
        score++;
        if (score >= 2)
        {
            Lose();
        }
    }

    public void Lose()
    {
        Debug.Log("You lose");
        fail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
