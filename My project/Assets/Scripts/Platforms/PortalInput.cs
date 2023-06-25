using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInput : MonoBehaviour
{
    [SerializeField] Transform[] portals;
    int index;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            index = Random.Range(0 , portals.Length);
            GameObject.FindGameObjectWithTag("Player").transform.position =  new Vector3(portals[index].transform.position.x ,portals[index].transform.position.y + 5, portals[index].transform.position.z);
        }
    }
}
