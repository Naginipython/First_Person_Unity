using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed = 7f;
    public float jumpForce = 5f;
    private bool isGrounded;
    private float zPos;
    private float xPos;
    private bool jumpReady;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //key controls
        zPos = Input.GetAxis("Vertical");
        xPos = Input.GetAxis("Horizontal");
        jumpReady = jumpReady? true : Input.GetButtonDown("Jump");
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.GetContact(0).normal.y > 0.8) {
            isGrounded = true;
        }
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody>().velocity = (new Vector3(xPos*speed, GetComponent<Rigidbody>().velocity.y, zPos*speed));

        if (jumpReady && isGrounded) {
            isGrounded = false;
            jumpReady = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce*2, 0), ForceMode.Impulse);
        }
    }

    
}