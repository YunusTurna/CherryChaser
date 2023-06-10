using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPlatforms: MonoBehaviour
{
    
    public Transform[] patrolPoints;
    public GameObject wall;
    public GameObject player;
    private int patrolPointIndex = 0;
    public float _speed = 2f;

    void Start()
    {
       
    }

    private void Update()
    {
        Transform pp = patrolPoints[patrolPointIndex];
        if (Vector3.Distance(transform.position, pp.position) < 0.01f)
        {
            patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;
        }
        else
        {
            wall.transform.position = Vector3.MoveTowards(transform.position, pp.position,_speed * Time.deltaTime);
        }
    }
    
    
   
}
