using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

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
}
