using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3;
    private float timer = 0;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
