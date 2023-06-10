using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBooster : MonoBehaviour
{
    public int power;
    

    
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Player")
       {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * power *Time.deltaTime, ForceMode.Impulse );
         CharacterMovement.grounded = true;
       }
        
    }
}
