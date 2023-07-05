using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private List<GameObject> availableObjects;
    GameObject selectedObject;

    private void Start()
    {
        InvokeRepeating("MakeClockFall", 0, 1);
        GameObject[] objectsToSelect = GameObject.FindGameObjectsWithTag("Ground");
        availableObjects = new List<GameObject>(objectsToSelect);
    }

    public void MakeClockFall()
    {


        if (Yelkovan.makeItFall == true)
        {
            if (availableObjects.Count == 0)
            {
                Debug.Log("All Ground objects have been selected.");
                return;
            }

            int randomIndex = Random.Range(0, availableObjects.Count);
            selectedObject = availableObjects[randomIndex];
            selectedObject.GetComponent<MeshCollider>().convex = true;
            selectedObject.GetComponent<Rigidbody>().isKinematic = false;
            selectedObject.GetComponent<Rigidbody>().useGravity = true;

            Yelkovan.makeItFall = false;
            Debug.Log("Selected Object: " + selectedObject.name);
            availableObjects.RemoveAt(randomIndex);
        }




    }




}
