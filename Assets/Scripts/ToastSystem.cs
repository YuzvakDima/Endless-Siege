using System.Collections;
using UnityEngine;
using TMPro;

public class ToastSystem : MonoBehaviour
{
    public static ToastSystem instance;

    [SerializeField] private GameObject toastPanel;
    [SerializeField] private TMP_Text toastText;
    [SerializeField] private float displayTime = 2f;

    private Coroutine currentToast;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        toastPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (currentToast != null) StopCoroutine(currentToast);
        currentToast = StartCoroutine(ShowToast(message));
    }

    private IEnumerator ShowToast(string message)
    {
        toastText.text = message;
        toastPanel.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        toastPanel.SetActive(false);
    }
}
