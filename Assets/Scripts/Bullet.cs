using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float damage;

    public GameObject bulletPrefab;
    public TowerData towerData;

    private void Start()
    {
        damage =  towerData.damage;
    }
    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            HitTarget();
        }

        if (transform.position.y <= 0.1f)
        {
            Destroy(gameObject); 
        }
    }

    private void HitTarget()
    {
        if (target.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
