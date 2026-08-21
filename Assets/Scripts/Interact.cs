using UnityEngine;

public class Interact : MonoBehaviour
{
    public Spawner spawner;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        Destroy(GameObject.FindWithTag("Character"));
        spawner.SpawnRandom();
    }

    void Update()
    {
        
    }
}
