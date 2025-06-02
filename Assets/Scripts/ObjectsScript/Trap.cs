using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapData trapData;
    [SerializeField] private float nextActivationTime;

    private Material trapMaterial; // ������� ������

    private void Start()
    {
        nextActivationTime = trapData.cooldown;

        // �������� �������, ���'������ � �������
        trapMaterial = GetComponent<Renderer>().material;

        // ���������� ���� ������
        SetTrapShaderReady(false);
    }

    private void Update()
    {
        if (nextActivationTime > 0)
        {
            nextActivationTime -= Time.deltaTime;

            // ���� ������ �� ������ � ������� ������
            if (nextActivationTime > 0.1f)
                SetTrapShaderReady(false);
        }

        // ���� ������ ������ � ������� ������
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
            SetTrapShaderReady(false); // ������ ���� ������� �� "�� ������"
        }
    }

    private void ActivateTrapEffect()
    {
        Debug.Log(trapData.trapName + " ����������!");
    }

    private void SetTrapShaderReady(bool isReady)
    {
        if (trapMaterial != null)
        {
            trapMaterial.SetFloat("_IsReady", isReady ? 1f : 0f);
        }
    }
}
