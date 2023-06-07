using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapInteraction : MonoBehaviour
{
    Rigidbody rb;
    public float turretBulletPushBack;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "TurretBullet")
        {
            Debug.Log("TurretBullet");
            rb.AddForce(Vector3.forward * turretBulletPushBack);
            
        }
    }
    
}
