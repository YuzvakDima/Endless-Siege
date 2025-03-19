using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField]  private float moveSpeed = 2f;
    public float health = 1f;

    [SerializeField] private EnemySpawner spawner;

    private Transform target;
    public int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= 0.5f)
        {
            if (pathIndex == (LevelManager.main.path.Length - 1))
            {
                Destroy(gameObject);
                LevelManager.main.lives--;
                spawner.enemiesAlive--;
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " отримав " + damage + " урону. Здоров'я: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " загинув!");
        Destroy(gameObject); // Видаляємо ворога зі сцени
        spawner.enemiesAlive--;
    }
}
