using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelChoice");
    }

    public void GameStatistic()
    {
        SceneManager.LoadScene("Statistics");
    }

    public void GoSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
