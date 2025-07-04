using System.Collections;
using System.Collections.Generic;
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
    public TMP_Text WinGame;
    public RectTransform panel;
    private float time;

    private void Awake()
    {
        gameOverMenu.gameObject.SetActive(false);
    }

    private void Start()
    {
        time = spawner.timeBetweenWaves;
        StartCoroutine(Timer(time));
    }

    private void Update()
    {
        resourcesText.text = "�������: " + resourceSystem.resources.ToString("F1");
        livesText.text = "�����: " + LevelManager.main.lives.ToString();
    }
    public void RestartLevel()
    {    
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOverMenu.gameObject.SetActive(false);
            GlobalReferences.totalResources += resourceSystem.resources;
    }

    public IEnumerator Timer(float time)
    {
        while (time > 0)
        {
            timeText.text = "���: " + Mathf.Round(time);
            yield return null; 
            time -= Time.deltaTime;
        }

        timeText.text = "���: " + 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameMenu()
    {
        panel.gameObject.SetActive(true);
    }

    public void OffMenu()
    {
        panel.gameObject.SetActive(false);
    }
}
