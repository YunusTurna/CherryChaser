using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Capusle : MonoBehaviour
{
    
    public int capsuleRiseSpeed;
    public int capsuleRiseTime;
    public float timeCounter;
    public bool riseOnce = true;
    public static int leaderBoardCounter = 0;
    
    public static string placement;
    
    public void Start()
    {
       
    }
    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" & riseOnce == true)
        {
            placement = other.gameObject.name;
            leaderBoardCounter = leaderBoardCounter +1;
            

             
            
            
            other.gameObject.transform.parent = this.gameObject.transform;
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x , other.gameObject.transform.position.y + 5 , other.gameObject.transform.position.z);
            StartCoroutine(CapsuleRise());
            riseOnce = false;

        }
    }
    IEnumerator CapsuleRise()
    {
       timeCounter = 0f;
        

        while(timeCounter < capsuleRiseTime)
        {
          
            transform.Translate(Vector3.up * capsuleRiseSpeed * Time.deltaTime);
            
            
            timeCounter += Time.deltaTime;
            yield return null;
        }
        
        
        

    }
}
