using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    private GameObject currentStructure;

    public enum pointType { trap, tower, barricade };

    public Collider pointCollider;

    private void Start()
    {
        pointCollider = GetComponent<Collider>();
        pointCollider.enabled = true;
    }
    public bool CanBuild()
    {
        return currentStructure == null;
    }

    public void Build(GameObject structurePrefab, Vector3 spawnPosition, Quaternion spawnRotate)
    {
        if (CanBuild())
        {
            currentStructure = Instantiate(structurePrefab, spawnPosition, spawnRotate);
            pointCollider.enabled = false;
        }
        else
        {
            Debug.Log("Тут вже є будівля!");
        }
    }
}