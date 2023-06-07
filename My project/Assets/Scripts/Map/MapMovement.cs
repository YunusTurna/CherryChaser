using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public float rotationSpeed;
     

    void Start()
    {
      

    }
    
    void FixedUpdate()
    {
        
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
   
}








