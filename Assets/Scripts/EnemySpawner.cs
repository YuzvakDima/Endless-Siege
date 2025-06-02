using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] enemyToSpawn;

    public int timeBetweenWaves = 10;
    private float timeSinceLastSpawn;
    [SerializeField] private float enemyPerSecond = 0.5f;
    [SerializeField] private int enemiesLeftToSpawn;
    public int enemiesAlive;
    private bool isSpawning = false;
    [SerializeField] private int baseEnemies = 4;
    private int wave = 1;
    private int totalWaves = 2;
    private float difficulty = 0.75f;

    [SerializeField] private UISystem UISystem;


    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        return;
        timeSinceLastSpawn += Time.deltaTime;
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
        if (timeSinceLastSpawn >= (1f / enemyPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        Debug.Log("Started Wave");
    }

    private void EndWave()
    {
        isSpawning = false;
        wave++;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
        Debug.Log("Ended Wave");
        StartCoroutine(UISystem.Timer(timeBetweenWaves));
        wave++;
        if (wave > totalWaves)
        {
            UISystem.WinGame.text = "mario your princess is in another castle";
            UISystem.WinGame.gameObject.SetActive(true);
            Debug.Log("mario your princess is in another castle");
            
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemyPrefab;
        Instantiate(enemyToSpawn, gameObject.transform.localPosition, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        Debug.Log(Mathf.RoundToInt(baseEnemies * wave - 2));
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(wave, difficulty));
    }
}
