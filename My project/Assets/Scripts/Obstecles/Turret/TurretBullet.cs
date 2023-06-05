using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    Rigidbody rb;
    public int firePower;
    public bool isFire = true;

    void Start()
    {
        firePower = 1000;
        rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire == true)
        {
            rb.AddForce(Vector3.forward * firePower );
            isFire = false;
        }
        Destroy(gameObject , 3);
        
    }
}
