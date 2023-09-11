using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioSource deathSound;
    private new Rigidbody2D rigidbody;
    public SpriteRenderer sprite;
    public float speed = 5;
    private HealthHolder health;

    void Start()
    {
        health = GetComponent<HealthHolder>();
        rigidbody = GetComponent<Rigidbody2D>();
        health.onDeath.AddListener(death);
    }

    private void death()
    {
        StartCoroutine(deathRoutine());
    }

    private IEnumerator deathRoutine()
    {
        deathSound.Play();
        yield return new WaitForSeconds(deathSound.clip.length);
        SceneManager.LoadScene("Death");
    }


    void Update()
    {
        if (health.dead)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            return;
        }

        var horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(horizontal, Input.GetAxis("Vertical")).normalized * speed;
        sprite.flipX = horizontal < 0;
    }
}