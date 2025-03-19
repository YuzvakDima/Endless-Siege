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
        StartCoroutine(Timer(time));
    }

    private void Update()
    {
        resourcesText.text = "Ðåñóðñ³â: " + resourceSystem.resources.ToString("F1");
        livesText.text = "Æèòò³â: " + LevelManager.main.lives.ToString();
    }
    public void RestartLevel(bool restart)
    {
        if (restart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOverMenu.gameObject.SetActive(false);
        }
    }

    public IEnumerator Timer(float time)
    {
        while (time > 0)
        {
            timeText.text = "×àñ: " + Mathf.Round(time);
            yield return null; 
            time -= Time.deltaTime;
        }

        timeText.text = "×àñ: " + 0;
    }
}
