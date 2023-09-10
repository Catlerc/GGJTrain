using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float rotateSpeed = 90;
    [Header("Sprites")]
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite rightUp, up, leftUp, left, leftDown, down, rightDown;
    private Sprite[] sprites;
    private Sprite currentSprite;
    private Transform target;
    private float targetDistance = 0;
    private Quaternion targetAngle = Quaternion.Euler(0, 0, 0);
    private Quaternion currentAngle = Quaternion.Euler(0, 0, 0);

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
        }
    }
    
    void Start()
    {
        sprites = new[] { right, rightUp, up, leftUp, left, leftDown, down, rightDown };
        currentSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void updateSprite()
    {
        float deltaAngle = 360f / sprites.Length;
        int index = (int)(currentAngle.z / deltaAngle + deltaAngle / 2);
        //currentSprite = sprites[index];
        print(index);
    }

    void updateAngle()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        currentAngle = Quaternion.RotateTowards(currentAngle, targetAngle, rotateSpeed * Time.fixedDeltaTime);
        updateSprite();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            updateAngle();
        }
    }
}
