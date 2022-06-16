using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float runspeed = 15f;

    //For animation:
    public bool iswalking;
    public Rigidbody rb;

    // For gravity:
    public Vector3 velocity;
    public float gravity = -9.8f;

    // For groundcheck:
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    public bool isgrounded;

    // To Jump:
    public float jumpheight = 3f;

    void start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //For groundcheck:
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //For movement:
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        iswalking = true;         

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
       
        //For sprinting:
        if (Input.GetKey(KeyCode.LeftShift))
        {
            iswalking = false;
            speed = runspeed;
        }
        else
        {
            speed = 8f;
        }

        // For Jumping:
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
      
        //For gravity:
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
