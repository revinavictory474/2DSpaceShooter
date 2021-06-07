using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemeHealth;
    [Space]
    public GameObject objBullet;
    public float shotTimeMin;
    public float shotTimeMax;
    public int shotChance;

    private void Start()
    {
        Invoke("OpenFire", Random.Range(shotTimeMin, shotTimeMax));
    }


    public void GetDamage(int damage)
    {
        enemeHealth -= damage;

        if(enemeHealth <=0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetDamage(1);
            Player.instance.GetDamage(1);
        }
    }

    private void OpenFire()
    {
        if (Random.value < (float)shotChance/100)
        {
            Instantiate(objBullet, transform.position, Quaternion.identity);
        }
    }
}
