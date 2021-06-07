using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemeHealth;

   

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
}
