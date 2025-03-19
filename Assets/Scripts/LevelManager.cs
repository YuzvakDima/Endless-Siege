using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [SerializeField] private EnemySpawner enemySpawner;

    public UISystem ui;

    public Transform[] path;

    public Scene scene;

    public int lives = 10;

    public float difficultyScale = 1;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            enemySpawner.gameObject.SetActive(false);
            ui.gameOverMenu.gameObject.SetActive(true);
        }
    }
}
