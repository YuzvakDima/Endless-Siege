using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    [SerializeField] EnemyBehaviour enemyBehaviour;
    public float health;
    public float lerpSpeed = 0.05f;

    void Start()
    {
        health = enemyBehaviour.maxHealth;
    }

    void LateUpdate()
    {
        health = enemyBehaviour.health;

        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }
}
