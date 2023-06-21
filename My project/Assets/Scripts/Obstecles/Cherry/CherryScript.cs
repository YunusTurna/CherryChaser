using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    [SerializeField] private int throwPower = 100;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.parent != null && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(transform.forward * throwPower * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject parent = other.gameObject;
            transform.parent = parent.transform;
            transform.localPosition = new Vector3(0, 10, 0);
            transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
