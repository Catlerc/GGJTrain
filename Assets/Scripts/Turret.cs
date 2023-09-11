using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
    [Header("Settings")] [SerializeField] private float rotateSpeed = 90;
    [SerializeField] private float reloadTime = 3;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bulletPrefab;
    [Header("Sprites")] [SerializeField] private Sprite right;
    [SerializeField] private Sprite rightUp, up, leftUp, left, leftDown, down, rightDown;
    private AudioSource shotSound;
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private float targetDistance = 0;
    private Quaternion targetAngle = Quaternion.Euler(0, 0, 0);
    private Quaternion currentAngle = Quaternion.Euler(0, 0, 0);
    private float reloadTimer = 0;

    public Transform Target
    {
        get => target;
        set { target = value; }
    }

    void fire()
    {
        reloadTimer -= Time.fixedDeltaTime;
        if (reloadTimer <= 0 && !target.Equals(null))
        {
            shotSound.pitch = Random.Range(0.7f, 1.3f);
            shotSound.Play();
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            float angle = currentAngle.eulerAngles.z * Mathf.Deg2Rad;
            float x = -Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 direction = new Vector2(x, y) * bulletSpeed;
            rb.AddForce(direction, ForceMode2D.Impulse);
            var from = transform.position;
            from.z = 0;
            var to = target.position;
            to.z = 0;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, to-from);
            reloadTimer = reloadTime;
        }
    }

    void Start()
    {
        sprites = new[] { up, leftUp, left, leftDown, down, rightDown, right, rightUp };
        spriteRenderer = GetComponent<SpriteRenderer>();
        shotSound = GetComponent<AudioSource>();
    }

    void updateSprite()
    {
        float deltaAngle = 360f / sprites.Length;
        int index = (int)((currentAngle.eulerAngles.z / deltaAngle + 0.5f) % sprites.Length);
        spriteRenderer.sprite = sprites[index];
    }

    void updateAngle()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        Vector3 dir = target.position - transform.position;
        targetAngle = Quaternion.LookRotation(Vector3.forward, dir);
        currentAngle = Quaternion.RotateTowards(currentAngle, targetAngle, rotateSpeed * Time.fixedDeltaTime);
        updateSprite();
    }

    private void FixedUpdate()
    {
        if (!target.Equals(null))
        {
            updateAngle();
            fire();
        }
    }
}