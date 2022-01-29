using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLock : MonoBehaviour
{
    public float distanceToclosestEnemy,distenemy;
    public Enemy closestEnemy = null;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        distanceToclosestEnemy = Mathf.Infinity;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach(Enemy currentenemy in allEnemies)
        {
            distenemy = (currentenemy.transform.position - player.transform.position).sqrMagnitude;

            if (distenemy < distanceToclosestEnemy)
            {
                distanceToclosestEnemy = distenemy;
                closestEnemy = currentenemy;
            }
        }

        Debug.DrawLine(player.transform.position, closestEnemy.transform.position);
    }

}
