using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : MonoBehaviour
{
    private bool DestroyCam = true;
    [SerializeField] private GameObject ownDeathCam;
    [SerializeField] private GameObject[] deathCams;
    [SerializeField] private int transationSpeed = 100;
    int i = 0;



    void Update()
    {
    if (DestroyCam == true)
        {
            
            Destroy(ownDeathCam);
            DestroyCam = false;
        }


        deathCams = GameObject.FindGameObjectsWithTag("DeathCams");
        transform.position = Vector3.MoveTowards(transform.position, deathCams[i].transform.position, transationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Q) & i <= deathCams.Length)
        {
            i = i + 1;

        }
        if (Input.GetKeyDown(KeyCode.Q) & i == deathCams.Length)
        {
            i = 0;
        }


    }
    
}
