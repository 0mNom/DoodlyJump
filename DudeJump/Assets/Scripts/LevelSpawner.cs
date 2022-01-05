using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject platformP;

    [SerializeField] private int numberOfPlatforms = 200;
    [SerializeField] private float minX, maxX, minY, maxY;



    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(minX, maxX);
           
            Instantiate(platformP, spawnPosition, Quaternion.identity);
        }
    }

    
}
