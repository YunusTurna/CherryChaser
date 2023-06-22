using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    [SerializeField] private int throwPower = 2000;
    [SerializeField] private int comeBackSpeed = 100;
    
    public bool comeBackMethod = false;
    [SerializeField]private GameObject Parent;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if(comeBackMethod == true & Parent != null)
        {
            ComeBackMethod();
            

        }
        if (transform.parent != null && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce((transform.forward + transform.up) * throwPower * Time.deltaTime, ForceMode.Impulse);
            
        }
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            comeBackMethod = false;
            Parent = other.gameObject;
            transform.parent = Parent.transform;
            transform.localPosition = new Vector3(1.5f, 3.6f, 4.5f);
            transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            comeBackMethod = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        
        
    }
    
    private void ComeBackMethod()
    {
        
        
        transform.position = Vector3.MoveTowards(transform.position , Parent.transform.GetChild(5).transform.position , comeBackSpeed * Time.deltaTime);
    }
}
