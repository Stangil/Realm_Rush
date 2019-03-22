using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //TODO Randomize spawn rate
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text scoreText;
    int score = 0;
   
    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnEnemys());
    }

    IEnumerator SpawnEnemys()//co-routine
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
