using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : MonoBehaviour
{
    [SerializeField] private GameObject[] deathCams;
    [SerializeField] private int transationSpeed = 100;
    int i = 0;
    

    
    void Update()
    {
        DeathState();

        
    }
    void DeathState()
    {
        deathCams = GameObject.FindGameObjectsWithTag("DeathCams");
        transform.position = Vector3.MoveTowards(transform.position , deathCams[i].transform.position ,  transationSpeed* Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.E) & i < deathCams.Length)
        {
            i = i+1;

        }
        if(Input.GetKeyDown(KeyCode.E) & i == deathCams.Length)
        {
            i = 0;
        }
        if(Input.GetKeyDown(KeyCode.Q) & i > 0)
        {
            i = i-1;

        }
        if(Input.GetKeyDown(KeyCode.Q) & i == 0)
        {
            i = deathCams.Length;

        }
        

    }
}
