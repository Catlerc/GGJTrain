using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private float startTimer = 5;
    [SerializeField] private float respawnTime = 3;
    [SerializeField] private float spawnZoneX = 10;
    [SerializeField] private float spawnZoneY = 10;
    [SerializeField] private GameObject monsterPrefab;
    private Camera camera;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(spawnZoneX, spawnZoneY);
        camera = FindObjectOfType<Camera>();
        InvokeRepeating(nameof(spawnEnemy), startTimer, respawnTime);
    }

    Vector3 getSpawnPosition()
    {
        while (true)
        {
            Vector3 cameraLeftDown = camera.ViewportToWorldPoint(new Vector3(0, 0));
            Vector3 cameraRightUp = camera.ViewportToWorldPoint(new Vector3(1, 1));
            Vector3 spawnLeftDown = cameraLeftDown - offset;
            Vector3 spawnRightUp = cameraRightUp + offset;
            float x = Random.Range(spawnLeftDown.x, spawnRightUp.x);
            float y = Random.Range(spawnLeftDown.y, spawnRightUp.y);
            if (Mathf.Clamp(x, cameraLeftDown.x, cameraRightUp.x) != x &&
                Mathf.Clamp(y, cameraLeftDown.y, cameraRightUp.y) != y)
            {
                return new Vector3(x, y);
            }
        }
    }

    void spawnEnemy()
    {
        GameObject enemy = Instantiate(monsterPrefab);
        enemy.transform.position = getSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
