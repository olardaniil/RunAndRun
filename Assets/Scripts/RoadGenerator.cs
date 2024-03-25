using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public Transform roadPrefab;
    public  float roadDistance;
    public float roadSpawnX;
    public float roadSpawnY;
    private float lastSpawnZ;
    private Transform camera;
    public float cameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform; // ссылка на об.MainCamera
        lastSpawnZ = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.position.z + cameraDistance > lastSpawnZ)
        {
            Transform roadTile;
            roadTile = Instantiate(roadPrefab);
            roadTile.position = new Vector3(roadSpawnX, roadSpawnY, lastSpawnZ + roadDistance);

            lastSpawnZ = roadTile.position.z;
        }
    }
}
