using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5f;     // Hareket hızı
    public float jumpForce = 5f;         // Zıplama kuvveti
    public float throwForce = 10f;
    public float mouseSensitivity = 2f;  // Fare hassasiyeti
    public static bool grounded = false;
    public bool throwBool = false;

    private float verticalRotation = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Fare imleci gizleniyor ve sınırları belirleniyor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) &throwBool == true)
        {
            Throw();

        }
        
        MovementMethod();
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(other.gameObject.tag == "Cherry")
        {
            throwBool = true;
        }
    }
    private void Throw()
    {
        GameObject.FindGameObjectWithTag("Cherry").GetComponent<Rigidbody>().AddForce(Vector3.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
        throwBool = false;
    }
    private void MovementMethod()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;

        
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;

        
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement = transform.rotation * movement;

       
        if((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) & grounded == true)
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }

        // Zıplama
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * 3;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed/3;
        }

        // Fare ile kamera rotasyonu
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, horizontalRotation, 0f);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

    }
}


