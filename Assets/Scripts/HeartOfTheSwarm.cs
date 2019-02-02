using System.Collections.Generic;
using UnityEngine;

public class HeartOfTheSwarm : MonoBehaviour
{
    public Transform boidPrefab;
    [UnityEngine.Range(10, 500)] public int swarmCount = 100;
    [UnityEngine.Range(10, 25)] public int spawnRadius = 25;
    public List<Transform> allBoids;



    void Start()
    {
        allBoids = new List<Transform>();
        for (var i = 0; i < swarmCount; i++)
        {
            Transform newBoid = Instantiate(boidPrefab, Random.insideUnitSphere * spawnRadius, Quaternion.identity);
            allBoids.Add(newBoid);
        }
    }

    public void setNewCounter(int counter, int spawnRadiusValue)
    {
        foreach(Transform t in allBoids)
        {
            Destroy(t.gameObject);
        }
        swarmCount = counter;
        spawnRadius = spawnRadiusValue;
        Start();
    }

}