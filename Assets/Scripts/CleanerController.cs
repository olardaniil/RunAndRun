using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CleanerController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        Destroy(other.gameObject);
    }
    

}
