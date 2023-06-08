using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
   
   public float currentTime;
   public float startingTime;
   [SerializeField] private GameObject log;

   [SerializeField] TextMeshPro countDownText;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1* Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            currentTime = 0;
            log.SetActive(true);
        }
        
        
    }
}
