using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject Cherry;
    [SerializeField] private Timer timer;

    public bool explosion = true;

    private void Awake()
    {
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    void Start()
    {
        timer = GameObject.Find("ExplosionTimer").GetComponent<Timer>();

    }


    void Update()
    {
        if (timer.countDown == 0 & explosion == true)
        {
            transform.position = Cherry.transform.position;
            explosion = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(Cherry);

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            
            
        }


      

    }
}
