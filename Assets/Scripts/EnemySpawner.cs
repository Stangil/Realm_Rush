using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //TODO Vary spawn rate
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject spawnPoint;
   
    void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    IEnumerator SpawnEnemys()//co-routine
    {
        while (true)
        {
            Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
            //print("Spawning...");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
