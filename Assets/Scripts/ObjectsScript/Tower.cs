using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData towerData;

    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private GameObject bulletPrefab;

    private float nextShotTime = 0f; 
    private Transform targetEnemy;

    private void Update()
    {
        FindTarget();
        if (targetEnemy != null && Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + fireRate; 
        }
    }

    private void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider collider in hitColliders)
        {
            if (collider.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
        }

        targetEnemy = closestEnemy;
    }

    private void Shoot()
    {
        if (targetEnemy == null) return;

        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetTarget(targetEnemy);
        }
    }
}
