using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            MoneyHolder.instance.add(5);
            
            var sound =GetComponent<AudioSource>();
            sound.pitch = Random.Range(0.7f, 1.3f);
            sound.Play();
            Destroy(gameObject, 2);
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<SpriteRenderer>());
        }
    }
}