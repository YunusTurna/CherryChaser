using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanges : MonoBehaviour
{
   [SerializeField] private GameObject[] MapParts;
  
    public float riseSpeed;
    private float timeCounter;
    
    int i = 0;


    void Start()
    {
        riseSpeed = 10f;
    }
  
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
           
           
           StartCoroutine(DestroyMapPart1());
           
        }
        
        
    }
    

    IEnumerator DestroyMapPart1()
    {
        

        for (i = 0; i <= 1; i++)
        {
            
            yield return new WaitForSeconds(5);
            
            MapParts[i+2].GetComponent<MapMovement>().enabled = true;
            
            
        
            MapParts[i+2].transform.parent = MapParts[0].transform;
            StartCoroutine(Rise(MapParts[i+2]));
            
            MapParts[i+1].SetActive(false);
        }
        
    }
    IEnumerator Rise(GameObject MapParts)
    {
        timeCounter = 0f;
        MapParts.GetComponent<MapMovement>().enabled = false;

        while(timeCounter < 1f)
        {
          
            MapParts.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            
            timeCounter += Time.deltaTime;
            yield return null;
        }
        MapParts.GetComponent<MapMovement>().enabled = true;
        
    }
    

    
}

