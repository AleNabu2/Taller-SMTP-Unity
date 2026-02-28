using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public float spawnRate = 1.5f;
    public float xRange = 7f;

    void OnEnable()
    {
        InvokeRepeating(nameof(SpawnFruit), 1f, spawnRate);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void SpawnFruit()
    {
        if (fruitPrefabs.Length == 0) return;

        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        Instantiate(fruitPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}