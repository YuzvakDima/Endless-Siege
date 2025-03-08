using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField]  private float moveSpeed = 2f;

    private Transform target;
    public int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= 0.5f)
        {
            if (pathIndex == (LevelManager.main.path.Length - 1))
            {
                Destroy(gameObject);
                LevelManager.main.lives--;
                return;
            }
            else
            {
                pathIndex++;
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
