using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;


    private int lineToMove = 1;
    public float lineDistance = 4;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeController.swipeRight && lineToMove < 2)
        {   
            Debug.Log(lineToMove);
            lineToMove++;
        }

        if (SwipeController.swipeLeft && lineToMove > 0)
        {
            lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
           if (controller.isGrounded)
               Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        } 
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log(other);
        }
        //Destroy(other.gameObject);
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
}
