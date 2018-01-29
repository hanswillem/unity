// Very simple third person controller


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{ 
    public float speed;
    public float jump;
    private Rigidbody rb;
    private bool jumping;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}


    // Update is called once per frame
    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        Vector3 moveBy = new Vector3(h * speed, 0.0f, 0.0f);

        rb.MovePosition(transform.position + moveBy * Time.deltaTime);

        if (Input.GetButton("Jump") && jumping == false)
        {
            jumping = true;
            rb.AddForce(0.0f, jump, 0.0f, ForceMode.Impulse);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Floor")
        {
            jumping = false;
        }
    }

}
