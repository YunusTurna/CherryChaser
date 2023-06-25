using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private GameObject cylenderBasePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cylenderBasePoint.transform.position.x, cylenderBasePoint.transform.position.y , cylenderBasePoint.transform.position.z);
    }
}
