// player controller script for moving left and right and jumping (platformer)
// attatch this script to a player game object that has a rigidbody component attached
// the ground objects in the scene need to have a "Platform" tag

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody rbody;
    private bool jumping;
    private bool isgrounded;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
        // move
        float h = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector3(h * speed, rbody.velocity.y, 0.0f);
        // jump
        if (jumping)
        {
            rbody.AddForce(0.0f, jumpforce, 0.0f, ForceMode.Impulse);
            jumping = false;
            isgrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
            isgrounded = true;
    }
}
 
