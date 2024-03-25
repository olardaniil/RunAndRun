using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleGenerator : MonoBehaviour
{
    public Transform[] obstaclePrefabs;
    public float[] spawnPosX;
    private float lastSpawnZ;

    private Transform camera;
    public float cameraDistance;

    void Start()
    {
        camera = Camera.main.transform;
        lastSpawnZ = 40;
    }

    void Update()
    {

        if (camera.position.z + cameraDistance > lastSpawnZ)
        {
            Transform obstacle;
            obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            obstacle.position = new Vector3(spawnPosX[Random.Range(0, spawnPosX.Length)], 0, lastSpawnZ + Random.Range(20, 30));

            lastSpawnZ = obstacle.position.z;
        }

    }
}
