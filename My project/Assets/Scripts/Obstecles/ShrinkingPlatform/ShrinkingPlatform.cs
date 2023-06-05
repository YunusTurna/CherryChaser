using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    private bool shrink = true;
    Animator anim;
    void Start()
    {
        InvokeRepeating("CoolDown" , 0 , 2);
        anim = GetComponent<Animator>();
    }

    
    
    private void OnCollisionEnter(Collision other) {
        if((other.gameObject.tag == "Player") & (shrink == true))
        {
            anim.SetBool("Shrink" , true);
            transform.localScale = new Vector3(transform.localScale.x/2 , transform.localScale.y , transform.localScale.z / 2);
            shrink = false;
            
        }
    }
    void CoolDown()
    {
        shrink = true;
    }

}
