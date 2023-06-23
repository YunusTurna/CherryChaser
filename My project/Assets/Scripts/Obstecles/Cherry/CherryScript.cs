using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    
    [SerializeField] private int horizontalThrowPower = 2000;
    [SerializeField] private int verticalThrowPower = 2000;
    [SerializeField] private int comeBackSpeed = 100;
    [SerializeField] private int rotateSpeed = 100;
    public static bool timerRun = false;
    public Vector3 rotation = new Vector3();

    public bool comeBackMethod = false;
    public bool grounded = false;
    public bool spin = false;
    [SerializeField] private GameObject Parent;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    private void Update()
    {
        
        if (transform.parent != null && Input.GetKeyDown(KeyCode.E))
        {
            timerRun = false;
            spin  = true;
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(((transform.forward * horizontalThrowPower) + (transform.up*verticalThrowPower)) * Time.deltaTime, ForceMode.Impulse);
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime , Space.Self);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = false;

        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            grounded = true;
        }
        if(spin == true)
        {
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime , Space.Self);
        }
       

    }
    private  void FixedUpdate()
    {
        if (comeBackMethod == true & Parent != null)
        {
            ComeBackMethod();


        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") & grounded == true )
        {
            timerRun = true;

            comeBackMethod = false;
            grounded = false;
            Parent = other.gameObject;
            transform.parent = Parent.transform;
            transform.localPosition = new Vector3(1.5f, 3.6f, 4.5f);
            transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
            spin = false;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            comeBackMethod = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            grounded = true;

        }


    }

    private void ComeBackMethod()
    {
        timerRun = false;


        transform.position = Vector3.MoveTowards(transform.position, Parent.transform.GetChild(5).transform.position, comeBackSpeed * Time.deltaTime);
    }
}
