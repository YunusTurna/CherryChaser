using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float countDown;

    private float timer = 0f;

    void Update()
    {
        if(CherryScript.timerRun == true){
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer -= 1f;
            countDown--;

            if (countDown <= 0)
            {
                countDown = 0;
                timerText.text = "BOOM";
                // İstediğiniz başka bir şeyi yapabilirsiniz
            }
        }
        timerText.text = countDown.ToString();
        if (countDown == 0)
        {
            timerText.text = "BOOM";
        }


    }
    }
}
