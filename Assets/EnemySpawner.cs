using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5;
    [SerializeField] Transform enemyToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemy()//co-routine
    {
        //print("Spawning...");
        while (true)
        {
            //    //print("Visiting Block: " + waypoint.name);
            //    transform.position = waypoint.transform.position;
            Instantiate(enemyToSpawn, new Vector3(0, 20, 0), Quaternion.identity);
            print("Spawning...");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        //print("Ending spawning");
    }
}
