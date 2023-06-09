using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBombMapInteraction : MonoBehaviour
{
    public int verticalBoosterPower;

    public int tiltedBoosterPower;



    Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "VerticalBooster")
        {
            VerticalBoosterMethod();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiltedBooster")
        {
            TiltedBooster();
        }
        
    }
    void VerticalBoosterMethod()
    {
        rb.AddForce(Vector3.up * verticalBoosterPower * Time.deltaTime, ForceMode.Impulse);
    }

    void TiltedBooster()
    {

        rb.AddForce((((Vector3.forward * tiltedBoosterPower) + (Vector3.up * Mathf.Abs(tiltedBoosterPower))) * Time.deltaTime), ForceMode.Impulse);
    }

}
