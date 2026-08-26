using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector3 spawnPosition;

    private List<GameObject> shuffledPrefabs;
    private int nextIndex = 0;
    public GameObject win;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        ShuffleList(); //the list of prefabs placed in a random order
    }

    private void ShuffleList()
    {
        shuffledPrefabs = new List<GameObject>(prefabs);

        for (int i = shuffledPrefabs.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (shuffledPrefabs[i], shuffledPrefabs[randomIndex]) = (shuffledPrefabs[randomIndex], shuffledPrefabs[i]);
        }

        nextIndex = 0;
    }

    public void SpawnRandom()
    {
        if (nextIndex >= shuffledPrefabs.Count)
        {
            Win();
            return;
        }

        GameObject prefab = shuffledPrefabs[nextIndex];
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        nextIndex++;
    }

    private void Win()
    {
        win.SetActive(true);
    }
}