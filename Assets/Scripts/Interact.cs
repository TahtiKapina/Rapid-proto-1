using UnityEngine;

public class Interact : MonoBehaviour
{
    public Spawner spawner;
    public AudioClip soundEffect;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        if (soundEffect != null)
        {
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        }

        Destroy(GameObject.FindWithTag("Character"));
        spawner.SpawnRandom();
    }

    void Update()
    {
        
    }
}
