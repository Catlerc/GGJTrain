using System;
using UnityEngine;

public class RenderOrderSorter : MonoBehaviour
{
    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        renderer.sortingOrder = -(int)(transform.position.y * 100);
    }
}