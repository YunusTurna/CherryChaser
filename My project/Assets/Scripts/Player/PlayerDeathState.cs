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
        DeathState();


    }
    void DeathState()
    {
        if (DestroyCam == true)
        {
            ownDeathCam.transform.parent = null;
            Destroy(ownDeathCam);
            DestroyCam = false;
        }


        deathCams = GameObject.FindGameObjectsWithTag("DeathCams");
        transform.position = Vector3.MoveTowards(transform.position, deathCams[i].transform.position, transationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E) & i <= deathCams.Length)
        {
            i = i + 1;

        }
        if (Input.GetKeyDown(KeyCode.E) & i == deathCams.Length)
        {
            i = 0;
        }



    }
}
