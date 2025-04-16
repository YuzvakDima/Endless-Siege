using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Statistic : MonoBehaviour
{
    [SerializeField] private TMP_Text totalKillsText;
    [SerializeField] private TMP_Text totalResourcesText;

    private void Update()
    {
        totalKillsText.text = "������ �������� ������: " + GlobalReferences.totalKills.ToString();
        totalResourcesText.text = "������ ����� �������: " + GlobalReferences.totalResources.ToString("F1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
