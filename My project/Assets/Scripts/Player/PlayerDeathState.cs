using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : MonoBehaviour
{
    [SerializeField] private GameObject[] deathCams;
    [SerializeField] private int transationSpeed = 100;
    int i = 0;
    

    private void Awake()
    {
      deathCams = GameObject.FindGameObjectsWithTag("DeathCams");
    }
    void Update()
    {
        DeathState();

        
    }
    void DeathState()
    {
        transform.position = Vector3.MoveTowards(transform.position , deathCams[i].transform.position ,  transationSpeed* Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.E) & i < deathCams.Length)
        {
            i = i+1;

        }
        if(Input.GetKeyDown(KeyCode.E) & i == deathCams.Length)
        {
            i = 0;
        }

    }
}
