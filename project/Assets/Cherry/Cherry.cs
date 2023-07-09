using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject referans;
    [SerializeField] public float speed;
    Rigidbody rb;
    public bool moveTowards = false;
    public static bool comeBack = false;
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.parent =null;

        }

        if(parent != null & comeBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(parent.transform.position.x , parent.transform.position.y +10 , parent.transform.position.z), speed * Time.deltaTime);

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            comeBack = true;

        }
        if (other.gameObject.tag == "Player")
        {
            //transform.position = referans.transform.transform.position;
            rb.velocity =  new Vector3(0,0,0);
            moveTowards = true;
            comeBack = false;
            parent = other.gameObject;
            this.gameObject.transform.parent = parent.transform;
        }

    }
}
