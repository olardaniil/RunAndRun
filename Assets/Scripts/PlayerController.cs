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
    [SerializeField] private GameObject losePanel;


    private int lineToMove;
    public float lineDistance = 4;

    // Start is called before the first frame update
    void Start()
    {   
        if (transform.position.x == -2)
        {
            lineToMove = 0;
        }
        else if (transform.position.x == 0)
        {
            lineToMove = 1;
        }
        else
        {
            lineToMove = 2;
        }

        controller = GetComponent<CharacterController>();

        losePanel.SetActive(false);
        Time.timeScale = 1;
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

        //transform.position = targetPosition;
        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {   
            losePanel.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.center = new Vector3();
        controller.Move(dir * Time.fixedDeltaTime);
    }
}
