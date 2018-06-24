using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float numEnemies;
    public float timeBetweenEnemies = 0.3f;

    private void Start()
    {
        NewWave(1);
    }

    private void NewWave(int waveNum)
    {
        numEnemies *= 2; //each wave has double the enemies of the previous wave

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)), transform);
    }
}
