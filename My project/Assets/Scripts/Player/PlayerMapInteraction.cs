using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapInteraction : MonoBehaviour
{
    public int bubiTrapPower;
    public int boosterPower;
    public int tiltedBoosterPower;
    public string boosterMode = "forward";
    [SerializeField] private GameObject[] boosters;
    
    Rigidbody rb;
    void Start()
    {
        InvokeRepeating("BoosterModeChangeMethod" , 0 , 3);
        rb = GetComponent<Rigidbody>();
        boosters = GameObject.FindGameObjectsWithTag("Boosters");
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BubiTrap")
        {
            BubiTrapMethod();
        }
        if(other.gameObject.tag == "Booster")
        {
            BoosterMethod();
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "TiltedBooster")
        {
            TiltedBooster();
        }
    }
    void BubiTrapMethod()
    {
        rb.AddForce(Vector3.up * bubiTrapPower , ForceMode.Impulse );
    }
    void BoosterMethod()
    {
        if(boosterMode == "forward")
        {
            rb.AddForce(new Vector3(1,0,0) * boosterPower , ForceMode.Impulse );
            
        }
        else
        {
            rb.AddForce(new Vector3(-1,0,0) * boosterPower , ForceMode.Impulse);
        }

    }
    void BoosterModeChangeMethod()
    {
        
        if(boosterMode == "forward")
        {
            boosterMode = "backward";
            for (int i = 0; i < boosters.Length; i++)
            {
                boosters[i].GetComponent<Renderer>().material.color =  new Color(0,0,0);
            }
           
        }
        else
        {
            boosterMode = "forward";
            for (int i = 0; i < boosters.Length; i++)
            {
                boosters[i].GetComponent<Renderer>().material.color =  new Color(255,255,255);
            }
        }

    }
    void TiltedBooster()
    {
        Debug.Log("Deneme");
        rb.AddForce(( ((Vector3.forward * tiltedBoosterPower) + (Vector3.up * Mathf.Abs(tiltedBoosterPower))) * Time.deltaTime)   , ForceMode.Impulse);
    }
    
}
