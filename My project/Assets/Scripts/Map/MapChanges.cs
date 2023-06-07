using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanges : MonoBehaviour
{
   [SerializeField] private GameObject[] MapParts;
  //Haritanın yükselme hızıdır.
      public float riseSpeed;

    private float timeCounter;
    //Her harita parçasının kaç saniyede bir yok olacağını gösteririr.
    public float destroyMapPartCounter = 5f;

    //Yükselen harita parçasının kaç saniye boyunca yükseleceğini gösterir.
    public float riseTime = 10f;

    
    
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
        

        for (i = 0; i <= MapParts.Length - 3; i++)
        {
            if(i == 1)
            {
                destroyMapPartCounter += 5;

            }
            
            yield return new WaitForSeconds(destroyMapPartCounter);
            
            
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

        while(timeCounter < 5)
        {
          
            MapParts.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            
            timeCounter += Time.deltaTime;
            yield return null;
        }
        MapParts.GetComponent<MapMovement>().enabled = true;
        Debug.Log(MapParts.transform.position.y);
        
        
    }
    

    
}

