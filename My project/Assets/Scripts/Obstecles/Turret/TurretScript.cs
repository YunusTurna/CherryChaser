using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private GameObject turretBullet;
    [SerializeField] Transform spawnPoint;
    Vector3 bulletSpawnPoint;
    void Start()
    {
        InvokeRepeating("Fire" , 1f , 1f);
        bulletSpawnPoint = new Vector3(spawnPoint.position.x , spawnPoint.position.y , spawnPoint.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
        Instantiate(turretBullet , bulletSpawnPoint , Quaternion.identity);
        
    }
}
