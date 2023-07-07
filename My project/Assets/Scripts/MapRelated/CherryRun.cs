using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryRun : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnPoint")
        {
            spawnPoint = other.gameObject;
        }
        if (other.gameObject == GameObject.Find("Respawn"))
        {
            this.gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
