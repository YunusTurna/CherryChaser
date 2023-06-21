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
        if(comeBackMethod == true)
        {
            ComeBackMethod();
            

        }
        if (transform.parent != null && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce((transform.forward + transform.up) * throwPower * Time.deltaTime, ForceMode.Impulse);
            
        }
        if(Vector3.Distance(transform.position , Parent.transform.position) > 5f)
        {
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            comeBackMethod = false;
            Parent = other.gameObject;
            transform.parent = Parent.transform;
            transform.localPosition = new Vector3(0, 8, 0);
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
        
        
        transform.position = Vector3.MoveTowards(transform.position , Parent.transform.position , comeBackSpeed * Time.deltaTime);
    }
}
