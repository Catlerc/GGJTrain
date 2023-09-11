using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceCursor : MonoBehaviour
{
    public StoreItem item;
    private Camera camera;


    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        var newPos = camera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        transform.position = newPos;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(item.prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void setItem(StoreItem item)
    {
        this.item = item;
        GetComponent<SpriteRenderer>().sprite = item.sprite;
    }
}