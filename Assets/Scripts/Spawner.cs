using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public static Spawner SharedInstance;
    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledCoins;
    public GameObject obstacles;
    public GameObject coins;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObstacles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(obstacles);
            tmp.SetActive(false);
            pooledObstacles.Add(tmp);
        }
        
        pooledCoins = new List<GameObject>();
        GameObject tmp1;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp1 = Instantiate(coins);
            tmp1.SetActive(false);
            pooledCoins.Add(tmp1);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObstacles[i].activeInHierarchy)
            {
                return pooledObstacles[i];
            }
        }
        return null;
    }
    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledCoins[i].activeInHierarchy)
            {
                return pooledCoins[i];
            }
        }
        return null;
    }
}
