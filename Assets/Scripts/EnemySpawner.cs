using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] enemyToSpawn;

    public int timeBetweenWaves = 10;
    private float timeSinceLastSpawn;
    private int enemiesPerWave = 10;
    private float enemyPerSecond = 0.5f;
    private int enemiesLeftToSpawn;
    private int enemiesAlive;
    private bool isSpawning = false;
    private int baseEnemies = 8;


    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemyPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemyPrefab;
        Instantiate(enemyToSpawn, gameObject.transform.localPosition, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return baseEnemies;
    }
}
