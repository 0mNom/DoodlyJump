using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject platformP, enemy1, theEnd;

    [SerializeField] private int numberOfPlatforms = 200;
    [SerializeField] private float minX, maxX, minY, maxY;



    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(minX, maxX);

            int x = Random.Range(0, 10);
            if (x == 1)
            {
                Instantiate(platformP, spawnPosition, Quaternion.identity);
                spawnPosition.y += 1; 
                Instantiate(enemy1, spawnPosition, Quaternion.identity);
            }
            else Instantiate(platformP, spawnPosition, Quaternion.identity);
        }

        spawnPosition.y += 4;
        spawnPosition.x = 0;
        Instantiate(theEnd, spawnPosition, Quaternion.identity);
    }

    
}
