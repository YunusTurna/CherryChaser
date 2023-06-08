using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject[] pizzaSlices;
    public int fallSpeed;
    public bool fallTrigger = false;
    public float timeCounter;
    public float fallTime;
    public List < int >  randomNumbers = new List< int >();
    public int count;
    public int min, max, randomPizzaSlice, counter;

    


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void GenerateUniqueNumber()
    {
        int randomNumber = -1;

        do { 
            randomNumber = Random.Range(min, max);
        } while (randomNumbers.Contains(randomNumber));

        
        randomNumbers.Add(randomNumber);
        count++;
        counter = count;
       randomPizzaSlice = randomNumber;
        Debug.Log(randomNumber);

        if (count >=(max-min))
        {
            count = 0;
            randomNumbers.Clear();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(counter< 12)
        {
            GenerateUniqueNumber();
            StartCoroutine(PizzaFall());
        }
        
            
        
        

        
    }
    IEnumerator PizzaFall()
    {
       timeCounter = 0f;
        

        while(timeCounter < fallTime)
        {
          
            pizzaSlices[randomPizzaSlice].transform.Translate(Vector3.back * fallTime * Time.deltaTime);
            
            
            timeCounter += Time.deltaTime;
            yield return null;
        }
        
        
        

    }
    

   

}
