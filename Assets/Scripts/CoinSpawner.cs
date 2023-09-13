using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int generateStartCoins = 5;
    [SerializeField] private float startSpawn = 3;
    [SerializeField] private float spawnSpeed = 3;
    [SerializeField] private GameObject coinPrefab;
    private Camera camera;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        for (int i = 0; i < generateStartCoins; i++)
        {
            spawnCoin();
        }
        InvokeRepeating(nameof(spawnCoin), startSpawn, spawnSpeed);
    }

    void spawnCoin()
    {
        Vector3 cameraLeftDown = camera.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 cameraRightUp = camera.ViewportToWorldPoint(new Vector3(1, 1));
        GameObject coin = Instantiate(coinPrefab);
        float x = Random.Range(cameraLeftDown.x, cameraRightUp.x);
        float y = Random.Range(cameraLeftDown.y, cameraRightUp.y);
        coin.transform.position = new Vector3(x, y);
    }
}
