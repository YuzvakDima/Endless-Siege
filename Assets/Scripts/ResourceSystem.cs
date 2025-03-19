using UnityEngine;
using TMPro;

public class ResourceSystem : MonoBehaviour
{
    public float resources;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private TMP_Text resourcesText;

    private void Start()
    {
        resourcesText = GetComponent<TMP_Text>();

        if (levelManager.difficultyScale == 1)
            resources = 100;
    }

    private void Update()
    {
        resources = resources + levelManager.difficultyScale * Time.deltaTime;
    }

}
