using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapData trapData; 

    [SerializeField] private float nextActivationTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && nextActivationTime <= 0.1)
        {
            other.GetComponent<EnemyBehaviour>().TakeDamage(trapData.damage);

            ActivateTrapEffect();

            nextActivationTime += trapData.cooldown;
        }
    }

    private void Update()
    {
        if (nextActivationTime <= 0)
            return;
        nextActivationTime -= Time.deltaTime;
    }

    private void ActivateTrapEffect()
    {
        Debug.Log(trapData.trapName + " активована!");
    }
}
