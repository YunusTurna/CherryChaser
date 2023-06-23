using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryInstatiate : MonoBehaviour
{
    [SerializeField] private Timer timer;
   [SerializeField] private GameObject OriginalCherry;
    [SerializeField] private GameObject InstantiatePosition;
    [SerializeField] private GameObject Cherry;

    private void Start()
    {
        timer = GameObject.Find("ExplosionTimer").GetComponent<Timer>();
        Cherry = Instantiate(OriginalCherry,  InstantiatePosition.transform.position , Quaternion.Euler(0,0,0));
    }

    private void Update() {
        if(Cherry == null)
        {
            timer.countDown = 10;
            Explosion.explosion = true;
            Cherry = Instantiate(OriginalCherry,  InstantiatePosition.transform.position , Quaternion.Euler(0,0,0));
        }
    }
}
