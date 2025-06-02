using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    public TowerData towerData;

    [SerializeField] private float fireRate;
    [SerializeField] private float attackRange;
    [SerializeField] private GameObject bulletPrefab;

    private float nextShotTime = 0f; 
    private Transform targetEnemy;

    private void Start()
    {
        fireRate = towerData.cooldown;
        attackRange = towerData.range;
    }
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

        
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position + new Vector3 (0,2), Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetTarget(targetEnemy);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
