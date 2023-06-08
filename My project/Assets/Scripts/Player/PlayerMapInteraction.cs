using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapInteraction : MonoBehaviour
{
    public int bubiTrapPower;
    public int boosterPower;
    public string boosterMode = "forward";
    [SerializeField] private GameObject booster;
    
    Rigidbody rb;
    void Start()
    {
        InvokeRepeating("BoosterModeChangeMethod" , 0 , 3);
        rb = GetComponent<Rigidbody>();
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
            booster.GetComponent<Renderer>().material.color =  new Color(0,0,0);
        }
        else
        {
            boosterMode = "forward";
            booster.GetComponent<Renderer>().material.color =  new Color(255,255,255);

        }

    }
    
}
