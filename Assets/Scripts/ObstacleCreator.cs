using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public float time;
    public GameObject[] spawnPoint;

    void Start()
    {
        InvokeRepeating("ActivateObstaclesAndCoins", 0.0f, time);
    }

    void ActivateObstaclesAndCoins()
    {
        List<int> spawnIndices = new List<int> { 0, 1, 2 };

        for (int i = 0; i < spawnIndices.Count; i++)
        {
            int temp = spawnIndices[i];
            int randomIndex = Random.Range(i, spawnIndices.Count);
            spawnIndices[i] = spawnIndices[randomIndex];
            spawnIndices[randomIndex] = temp;
        }

        for (int i = 0; i < 2; i++)
        {
            GameObject obstacle = Spawner.SharedInstance.GetPooledObject();
            if (obstacle != null)
            {
                obstacle.transform.position = spawnPoint[spawnIndices[i]].transform.position;
                obstacle.transform.rotation = spawnPoint[spawnIndices[i]].transform.rotation;
                obstacle.SetActive(true);
            }
        }

        GameObject coin = Spawner.SharedInstance.GetPooledObject2();
        if (coin != null)
        {
            coin.transform.position = spawnPoint[spawnIndices[2]].transform.position;
            coin.transform.rotation = spawnPoint[spawnIndices[2]].transform.rotation;
            coin.SetActive(true);
        }
    }
}
