using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float health;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private Slider healthBar;

    public float Health
    {
        get => health;
        set
        {
            health = value;
            healthBar.value = Mathf.Clamp(health / maxHealth, 0, 1);
            if (health <= 0) Destroy(gameObject);
        }
    }

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!target.Equals(null))
        {
            Vector2 deltaVector = target.position - transform.position;
            spriteRenderer.flipX = deltaVector.x < 0;
            rb.AddForce(deltaVector.normalized * (speed * Time.fixedDeltaTime), ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bullet(Clone)")
        {
            Health -= 10;
        }
    }
}
