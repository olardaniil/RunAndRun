using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public Transform[] worldPrefabs;
    public float worldDistance;
    public float worldSpawnX;
    public float worldSpawnY;
    private float lastSpawnZ;
    private Transform camera;
    public float cameraDistance;

    void Start()
    {
        camera = Camera.main.transform;
        lastSpawnZ = -300;
    }

   
    void Update()
    {
        if (camera.position.z + cameraDistance > lastSpawnZ)
        {
            Transform worldTile;
            worldTile = Instantiate(worldPrefabs[Random.Range(0, worldPrefabs.Length)]);
            worldTile.position = new Vector3(worldSpawnX, worldSpawnY, lastSpawnZ + worldDistance);

            lastSpawnZ = worldTile.position.z;
        }
    }
}
