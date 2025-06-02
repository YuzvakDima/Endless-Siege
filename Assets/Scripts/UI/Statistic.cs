using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Statistic : MonoBehaviour
{
    [SerializeField] private TMP_Text totalKillsText;
    [SerializeField] private TMP_Text totalResourcesText;
    [SerializeField] private RectTransform alertDialog;

    private void Update()
    {
        totalKillsText.text = "Усього вбито ворогів: " + GlobalReferences.totalKills.ToString();
        totalResourcesText.text = "Усього отримано ресурсів: " + GlobalReferences.totalResources.ToString("F1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClearStatistic()
    {
        alertDialog.gameObject.SetActive(true);
    }

    public void NoButton()
    {
        alertDialog.gameObject.SetActive(false);
    }

    public void YesButton()
    {
        GlobalReferences.totalResources = 0;
        GlobalReferences.totalKills = 0;
        alertDialog.gameObject.SetActive(false);
    }
}
