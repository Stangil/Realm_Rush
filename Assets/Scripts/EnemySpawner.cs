using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //TODO Randomize spawn rate
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;//maybe vary or speed up spawn rate
    [SerializeField] float decreaseSecondsBetweenSpawns = 0.00001f;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnSFX;
    int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnEnemys());
    }
    private void Update()
    {
        secondsBetweenSpawns -= decreaseSecondsBetweenSpawns;
    }
    IEnumerator SpawnEnemys()//co-routine
    {
        while (true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            var newEnemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
   


    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
