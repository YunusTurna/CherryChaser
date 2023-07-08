using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yelkovan : MonoBehaviour
{
    public Transform pivotPoint;
    public static bool makeItFall = false;
    public float rotationSpeed = 1f;

    private void Update()
    {
        RotateClockHand();
    }

    private void RotateClockHand()
    {
        transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "LapCounter")
        {
            makeItFall = true;
            
        }
        else
        {
            makeItFall = false;
        }
    }

}
