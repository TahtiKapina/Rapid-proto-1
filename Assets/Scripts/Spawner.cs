using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector3 spawnPosition;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void SpawnRandom()
    {
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
