using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularBooster : MonoBehaviour
{
    

    public float launchForce = 10f;  // Fırlatma kuvveti
    public static bool  addForce = false;
    
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
       {
        addForce = true;
        other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        other.gameObject.GetComponent<Rigidbody>().AddForce(((Vector3.forward * launchForce) + (Vector3.up * Mathf.Abs(launchForce))) * Time.deltaTime, ForceMode.Impulse);
        
        
        
        
            
        
        
        
       }

    }

    
    
}
