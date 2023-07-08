using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBBooster : MonoBehaviour
{
    public float pushPower;
    public string forwardOrBackward;
    
    private void Start()
    {
        forwardOrBackward = "forward";
        InvokeRepeating("Change" , 0 , 2);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" & forwardOrBackward == "forward")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushPower * Time.deltaTime , ForceMode.Impulse );
        }
        if (other.gameObject.tag == "Player" & forwardOrBackward == "backward")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushPower * Time.deltaTime , ForceMode.Impulse );
        }

    }
    void Change()
    {
        if(forwardOrBackward == "forward")
        {
            forwardOrBackward = "backward";
        }
        if(forwardOrBackward == "backward")
        {
            forwardOrBackward = "forward";
        }

    }
}
