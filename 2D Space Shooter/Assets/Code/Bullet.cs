using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isEnemyBullet;


    public void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isEnemyBullet && collision.tag == "Player")
        {
            Player.instance.GetDamage(damage);
            Destruction();
        }
        else if (!isEnemyBullet && collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            Destruction();
        }
    }
}
