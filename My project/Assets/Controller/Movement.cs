using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 moveVal;
    public float moveSpeed = 10f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    public void Moving(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            Debug.Log("Performed");
            moveVal = value.ReadValue<Vector2>();
            Debug.Log(moveVal.x + " "+ moveVal.y);
           
        }
        if(value.canceled)
        {
            moveVal= value.ReadValue<Vector2>();
        }
    }
}
