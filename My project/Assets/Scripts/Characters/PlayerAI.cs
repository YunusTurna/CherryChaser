using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public GameObject log;
    public GameObject finalPoint;
    public float speed;
    private bool moveTowards;

    void Start()
    {
      
    }

    
    void Update()
    {
        if(moveTowards == true)
        {
            log.transform.position = Vector3.MoveTowards(log.transform.position,new Vector3(finalPoint.transform.position.x,finalPoint.transform.position.y +10,finalPoint.transform.position.z ) , speed * Time.deltaTime);

        }
        
    }
    private void OnCollisionEnter(Collision other) {
        moveTowards = true;
    }
}
