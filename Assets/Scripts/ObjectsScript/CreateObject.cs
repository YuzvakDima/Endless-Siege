using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    Camera cam;
    [SerializeField] private ResourceSystem resourceSystem;
    [SerializeField] private GameObject barricade;
    [SerializeField] private RectTransform towerPanel;
    [SerializeField] private RectTransform trapPanel;

    private void Start()
    {
        resourceSystem = FindAnyObjectByType<ResourceSystem>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryBuild();
        }
    }

    private void TryBuild()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent<BuildPoint>(out BuildPoint buildPoint))
            {
                if (buildPoint.CompareTag("Trap"))
                {
                    towerPanel.gameObject.SetActive(false);
                    trapPanel.gameObject.SetActive(true);
                    FindAnyObjectByType<Defence>().SetBuildPoint(buildPoint);
                }
                else if (buildPoint.CompareTag("Tower"))
                {
                    trapPanel.gameObject.SetActive(false);
                    towerPanel.gameObject.SetActive(true);
                    FindAnyObjectByType<Defence>().SetBuildPoint(buildPoint);
                }
                else if (buildPoint.CompareTag("Barricade") && resourceSystem.resources >= 50)
                {
                    Vector3 position = buildPoint.transform.position;
                    position.y = 0.1f;
                    Quaternion rotation = buildPoint.transform.rotation;
                    buildPoint.Build(barricade, position, rotation);
                    resourceSystem.resources -= 50;
                }
                else
                {
                    ToastSystem.instance.ShowMessage("Недостатньо ресурсів!");
                }
            }
        }
    }
}