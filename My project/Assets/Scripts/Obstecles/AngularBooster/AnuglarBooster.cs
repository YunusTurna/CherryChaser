using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnuglarBooster : MonoBehaviour
{
    

    public float launchForce = 10f;  // Fırlatma kuvveti
    private void Start() {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
       {
        other.gameObject.GetComponent<Rigidbody>().AddForce(((Vector3.forward * launchForce) + (Vector3.up * Mathf.Abs(launchForce))) * Time.deltaTime, ForceMode.Impulse );
        
        
       }
    }
    
}
