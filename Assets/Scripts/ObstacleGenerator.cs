using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public Transform[] obstaclePrefabs;
    public float[] spawnPosX;
    private DateTime lastTimeSpawnObstacle;

    private Transform camera;
    public float cameraDistance;

    void Start()
    {
        camera = Camera.main.transform;
        lastTimeSpawnObstacle = DateTime.Now;

    }

    void Update()
    {
        //if (camera.position.z + cameraDistance > lastSpawnZ)
        {   
          //  Transform obstacle;
            //obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            //obstacle.position = new Vector3(spawnPosX[Random.Range(0, spawnPosX.Length)], 0, Random.Range(lastSpawnZ, lastSpawnZ+10f));

//            lastSpawnZ = obstacle.position.z;
        }
    }
}
