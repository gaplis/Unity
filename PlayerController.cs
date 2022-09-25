using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed player")]
    public float speed = 7f;

    [Header("Run speed player")]
    public float runSpeed = 15f;
    
    [Header("Run speed left and right player")]
    public float runLefRightSpeed = 12f;

    [Header("Force jump")]
    public float jumpPower = 200f;

    [Header("On the ground?")]
    public bool ground;

    public Rigidbody rb;

    private void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.S))
        {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.right * runLefRightSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.right * runLefRightSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(ground == true)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
}
