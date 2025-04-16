using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private string killPlayerPref = "Kills";
    [SerializeField] private string resourcesPlayerPref = "Resources";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GlobalReferences.totalKills = PlayerPrefs.GetInt(killPlayerPref, 0);
        GlobalReferences.totalResources = PlayerPrefs.GetFloat(resourcesPlayerPref, 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(killPlayerPref, GlobalReferences.totalKills);
        PlayerPrefs.SetFloat(resourcesPlayerPref, GlobalReferences.totalResources);
    }
}
