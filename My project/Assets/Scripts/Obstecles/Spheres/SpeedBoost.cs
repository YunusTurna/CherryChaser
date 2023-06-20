using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    [SerializeField] GameObject player;
    public int boostTime = 3;
    public int multiplayer = 3;
    public bool runMethod = false;



    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            runMethod = true;
            player = other.gameObject;
            if (runMethod == true)
            {
                StartCoroutine(SpeedBoostMethod());
            }
            
        }
    }
    IEnumerator SpeedBoostMethod()
    {
        runMethod = false;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //player.GetComponent<CharacterMovement>().movementSpeed = player.GetComponent<CharacterMovement>().movementSpeed * multiplayer;
        yield return new WaitForSeconds(boostTime);
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //player.GetComponent<CharacterMovement>().movementSpeed = player.GetComponent<CharacterMovement>().movementSpeed / multiplayer;
        


    }
}
