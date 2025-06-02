using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField]  private float moveSpeed = 2f;
    public float maxHealth = 100;
    public float health;
    public float damage = 5f;

    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private ResourceSystem resourceSystem;

    private Transform target;
    public int pathIndex = 0;

    private Barricade currentBarricade;

    private void Start()
    {
        health = maxHealth;
        target = LevelManager.main.path[pathIndex];
        spawner = FindObjectOfType<EnemySpawner>();
        resourceSystem = FindObjectOfType<ResourceSystem>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (currentBarricade == null) 
        {
            if (Vector3.Distance(target.position, transform.position) <= 1f)
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
    }

    private void FixedUpdate()
    {
        if (currentBarricade == null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        CheckForBarricade();
    }

    private void CheckForBarricade()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider collider in hitColliders)
        {
            if (collider.TryGetComponent<Barricade>(out Barricade barricade))
            {
                if (currentBarricade == null)
                {
                    currentBarricade = barricade;
                    StartCoroutine(AttackBarricade());
                }
                return;
            }
        }
        currentBarricade = null;
    }

    private IEnumerator AttackBarricade()
    {
        while (currentBarricade != null) 
        {
            currentBarricade.TakeDamage(damage);
            yield return new WaitForSeconds(1f); 
        }
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
        Destroy(gameObject); 
        spawner.enemiesAlive--;
        resourceSystem.resources += 10;
        GlobalReferences.totalResources += 10;  
        GlobalReferences.totalKills++;
    }
}
