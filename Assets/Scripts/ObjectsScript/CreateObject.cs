using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    Camera cam;
    [SerializeField] private GameObject[] structures; 
    [SerializeField] private ResourceSystem resourceSystem;

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
                if (buildPoint.CompareTag("Trap") && resourceSystem.resources >= 50)
                {
                    Vector3 position = buildPoint.transform.position;
                    position.y = -0.5f;
                    buildPoint.Build(structures[1], position, Quaternion.identity.normalized);
                    resourceSystem.resources -= 50;
                }
                else if (buildPoint.CompareTag("Tower") && resourceSystem.resources >= 100)
                {
                    Vector3 position = buildPoint.transform.position;
                    position.y = 2f;
                    position.z += -0.5f;
                    buildPoint.Build(structures[0], position, Quaternion.identity.normalized);   
                    resourceSystem.resources -= 100;
                }
                else if (buildPoint.CompareTag("Barricade") && resourceSystem.resources >= 50)
                {
                    Vector3 position = buildPoint.transform.position;
                    position.y = 0.1f;
                    Quaternion rotation = buildPoint.transform.rotation;
                    buildPoint.Build(structures[2], position, rotation); 
                    resourceSystem.resources -= 50;
                }
                else
                {
                    Debug.Log("Недостатньо ресурсів");
                }
            }
        }
    }
}
