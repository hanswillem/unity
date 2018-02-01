using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float jump;
    private bool isjumping;
    Rigidbody rb;
    private bool isgrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            isjumping = true;
    }


    private void FixedUpdate()
    {
        // move horizontal
        float h = Input.GetAxis("Horizontal");
        rb.MovePosition(transform.position + new Vector3(h * speed * Time.deltaTime, 0.0f, 0.0f));

        if (isjumping && isgrounded)
            rb.AddForce(0.0f, jump, 0.0f, ForceMode.Impulse);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Platform")
            isgrounded = true;
    }

}
