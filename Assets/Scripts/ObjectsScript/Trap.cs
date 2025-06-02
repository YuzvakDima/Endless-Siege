using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapData trapData;
    [SerializeField] private float nextActivationTime;

    private Material trapMaterial; // ћатер≥ал пастки

    private void Start()
    {
        nextActivationTime = trapData.cooldown;

        // ќтримати матер≥ал, пов'€заний з пасткою
        trapMaterial = GetComponent<Renderer>().material;

        // ≤н≥ц≥ал≥зуЇмо стан пастки
        SetTrapShaderReady(false);
    }

    private void Update()
    {
        if (nextActivationTime > 0)
        {
            nextActivationTime -= Time.deltaTime;

            // якщо пастка не готова Ч оновити шейдер
            if (nextActivationTime > 0.1f)
                SetTrapShaderReady(false);
        }

        // якщо пастка готова Ч оновити шейдер
        if (nextActivationTime <= 0.1f)
            SetTrapShaderReady(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && nextActivationTime <= 0.1f)
        {
            other.GetComponent<EnemyBehaviour>().TakeDamage(trapData.damage);

            ActivateTrapEffect();

            nextActivationTime = trapData.cooldown;
            SetTrapShaderReady(false); // «м≥нити стан шейдера на "не готова"
        }
    }

    private void ActivateTrapEffect()
    {
        Debug.Log(trapData.trapName + " активована!");
    }

    private void SetTrapShaderReady(bool isReady)
    {
        if (trapMaterial != null)
        {
            trapMaterial.SetFloat("_IsReady", isReady ? 1f : 0f);
        }
    }
}
