using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public Canvas gameOverMenu;
    [SerializeField] private ResourceSystem resourceSystem;
    [SerializeField] private EnemySpawner spawner;
    public TMP_Text resourcesText;
    public TMP_Text livesText;
    public TMP_Text timeText;
    private float time;
    bool restart;

    private void Awake()
    {
        gameOverMenu.gameObject.SetActive(false);
    }

    private void Start()
    {
        time = spawner.timeBetweenWaves;
    }

    private void Update()
    {
        resourcesText.text = "Ресурсів: " + resourceSystem.resources.ToString();
        livesText.text = "Життів: " + LevelManager.main.lives.ToString();
        timeText.text = "Час: " + Mathf.Round(time);
        time -= Time.deltaTime;
    }
    public void RestartLevel(bool restart)
    {
        if (restart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOverMenu.gameObject.SetActive(false);
        }
    }
}
