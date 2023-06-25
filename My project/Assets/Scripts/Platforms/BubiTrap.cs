using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobyTrap : MonoBehaviour
{
  
  public GameObject[] bubiSpawnPoints;
  private int randomNumber;
  
 void Start()
 {
   InvokeRepeating("BubiChangePosition" , 0 , 3);
 }
 
 void BubiChangePosition()
 {
  randomNumber = Random.Range(0,bubiSpawnPoints.Length);
  gameObject.SetActive(true);
  gameObject.transform.position = bubiSpawnPoints[randomNumber].transform.position;
  
 }



 
 

  
 
    

}
