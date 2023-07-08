using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    [SerializeField] private Timer timer;

    public static bool explosion = true;
 

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
            transform.position = GameObject.Find("CherryBomb(Clone)").transform.position;
            explosion = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(GameObject.Find("CherryBomb(Clone)"));
            CherryScript.timerRun = false;

        }

    }
    
}
