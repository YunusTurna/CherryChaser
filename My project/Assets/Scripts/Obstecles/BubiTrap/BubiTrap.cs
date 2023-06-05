using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobyTrap : MonoBehaviour
{
  private float jumpForce = 20f;
  Rigidbody rb;
 void Start()
 {
    rb = GetComponent<Rigidbody>();
 }
 
 private void OnCollisionEnter(Collision other)
 {
  if(other.gameObject.tag == "JumperTrap")
  {
    Debug.Log("Denemeee");
    rb.AddForce(transform.up * jumpForce , ForceMode.Impulse);
  }
 }

  
 
    

}
