using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject objBullet;
    public float timeBulletSpawn;
    [HideInInspector] public float timerShot;

    private void Update()
    {
        if(Time.time > timerShot)
        {
            timerShot = Time.time + timeBulletSpawn;
            Instantiate(objBullet, transform.position, Quaternion.identity);
        }
    }
}
