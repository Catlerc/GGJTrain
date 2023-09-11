using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public SpriteRenderer sprite;
    public float speed = 5;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(horizontal, Input.GetAxis("Vertical")).normalized * speed;
        sprite.flipX = horizontal < 0;

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
    }
}