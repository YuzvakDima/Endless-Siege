using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [SerializeField] private RectTransform towerPanel;
    [SerializeField] private RectTransform trapPanel;
    [SerializeField] private CreateObject createObject;
    [SerializeField] private BuildPoint buildPoint;
    [SerializeField] private ResourceSystem resourceSystem;

    public GameObject[] towers;
    public GameObject[] traps;

    public void SetBuildPoint(BuildPoint point)
    {
        buildPoint = point;
    }

    public void TowerArcher()
    {
        if (resourceSystem.resources < 100)
        {
            ToastSystem.instance.ShowMessage("Недостатньо ресурсів");
            return;
        }
        else
        {
            Vector3 position = buildPoint.transform.position;
            buildPoint.Build(towers[0], position, Quaternion.identity.normalized);
            resourceSystem.resources -= 100;
            towerPanel.gameObject.SetActive(false);
        }
    }

    public void TowerSniper()
    {
        if (resourceSystem.resources < 150)
        {
            ToastSystem.instance.ShowMessage("Недостатньо ресурсів");
            return;
        }
        else
        {
            Vector3 position = buildPoint.transform.position;
            buildPoint.Build(towers[1], position, Quaternion.identity.normalized);
            resourceSystem.resources -= 150;
            towerPanel.gameObject.SetActive(false);
        }           
    }

    public void TrapPoison()
    {
        if (resourceSystem.resources < 75)
        {
            ToastSystem.instance.ShowMessage("Недостатньо ресурсів");
            return;
        }
        else
        {
            Vector3 position = buildPoint.transform.position;
            buildPoint.Build(traps[0], position, Quaternion.identity.normalized);
            resourceSystem.resources -= 75;
            trapPanel.gameObject.SetActive(false);
        }
    }
}
