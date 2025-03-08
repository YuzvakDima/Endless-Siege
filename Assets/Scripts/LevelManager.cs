using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public UISystem ui;

    public Transform[] path;

    public int lives = 10;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            Debug.Log("GameOver");
            this.gameObject.SetActive(false);
            ui.gameOverMenu.gameObject.SetActive(true);
        }
    }
}
