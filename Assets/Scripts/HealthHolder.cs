using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthHolder : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public UnityEvent<float> onHealthChange = new();
    public UnityEvent onDeath = new();
    public bool dead = false;

    private void Start() => health = maxHealth;

    public void damage(float value)
    {
        health = health - value;
        if (health < 0)
        {
            health = 0;
            dead = true;
            onDeath.Invoke();
        }

        onHealthChange.Invoke(health);
    }

    private void Update()
    {
        if (Input.GetKeyDown("e")) damage(10); // TODO: нужно только для теста. удалить при рабочих противниках
    }
}