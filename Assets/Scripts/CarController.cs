using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        Vector3 vector = new Vector3(transform.position.x, transform.position.y, transform.position.z -1);
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
    
}
