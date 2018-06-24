using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float enemySpeed = 2f;
    public int enemiesPerSecond = 1;
    public float increaseSpawnRateTime = 5f; //every increaseSpawnRateTime seconds, we increase enemiesPerSecond by 1
    public float increaseSpeedFactor = 0.05f;
    public float increaseSpeedTime = 2f; //every increaseSpeedTime seconds, we increase enemySpeed by (increaseSpeedPercentageAmount * 100)%

    private void Start()
    {
        StartCoroutine(IncreaseEnemiesPerSecond());
        StartCoroutine(IncreaseEnemiesSpeed());
        StartCoroutine(SpawnEnemies());


    }

    IEnumerator IncreaseEnemiesPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseSpawnRateTime);

            enemiesPerSecond += 1;
        }

    }

    IEnumerator IncreaseEnemiesSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseSpeedTime);

            enemySpeed += enemySpeed * increaseSpeedFactor;
        }

    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for(int i = 0; i < enemiesPerSecond; i++)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnEnemy()
    {
        Debug.Log("Spawning Enemy");
        GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.value * 360)), transform);

        enemyObj.GetComponent<Rigidbody2D>().velocity = enemyObj.transform.up * enemySpeed;
    }
}
