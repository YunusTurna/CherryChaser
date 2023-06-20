using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinAnimation : MonoBehaviour
{
    Rigidbody rb;
    private bool grounded;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        Jump();
        Run();
       


    }
    void Walk()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }



    }
    void Jump()
    {
        if (grounded == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

    }
    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) & (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Deneme");
            grounded = true;
        }
    }
 private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

}
