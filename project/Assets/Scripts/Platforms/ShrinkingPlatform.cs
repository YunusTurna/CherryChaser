using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    private bool shrink = false;
    Animator anim;
    void Start()
    {
       
        anim = GetComponent<Animator>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.SetBool("Shrink" , true);
        }
    }
    

}
