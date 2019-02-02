using UnityEngine;

public class HeartOfTheSwarm : MonoBehaviour
{
    public Transform boidPrefab;
    [UnityEngine.Range(10, 500)] public int swarmCount = 100;
    [UnityEngine.Range(10, 25)] public int spawnRadius = 25;



    void Start()
    {
        for (var i = 0; i < swarmCount; i++)
        {
            Instantiate(boidPrefab, Random.insideUnitSphere * spawnRadius, Quaternion.identity);
        }
    }
}