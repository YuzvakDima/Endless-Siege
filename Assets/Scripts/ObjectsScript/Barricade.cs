using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    public BarricadeData barricadeData; 
    private float health;

    private void Start()
    {
        health = barricadeData.health; 
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"�������� {barricadeData.barricadeName} �������� {damage} �����. ������'�: {health}");

        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
