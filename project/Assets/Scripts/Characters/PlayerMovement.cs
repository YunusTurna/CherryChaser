using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMovement : MonoBehaviourPunCallbacks
{

    public float movementSpeed = 5f;
    public static bool rearrangeDeathCam;
    
    

    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private GameObject deathCam;
    [SerializeField] private GameObject freelookcam;
    public float jumpPower = 10f;
    public bool grounded = false;
    

    private Transform cameraTransform;
   
    private Rigidbody rb;
    private bool cursorLocked = true;
    public Vector3 movement;



   
    private void Start()
    {
       


        
        rb = GetComponent<Rigidbody>();
        LockCursor();
    }
    private void FixedUpdate()
    {   

        Movement();     
    }
    
    private void Movement()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kamera yönünü hesapla
        //Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        // movementDirection = (verticalInput * cameraForward + horizontalInput * cameraTransform.right).normalized;

        //if (AngularBooster.addForce == false)
        {
          //  Vector3 movement = movementDirection * movementSpeed;


           // rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        }
        // Karakterin yönünü kamera yönüne ayarla
       // if (movementDirection != Vector3.zero)
       // {
         //   Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
       // }

        // Imleci kilitleme/kilidini açma
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor();
        }
        // Zıplama
        if (Input.GetKey(KeyCode.Space) & grounded == true)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    private void LockCursor()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
            AngularBooster.addForce = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Explosion")
        {
            rearrangeDeathCam = true;
            gameObject.GetComponent<PlayerDeathState>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            Destroy(deathCam);
        }
        
    }
   

}
