using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemyHealth;
    public int scoreValue; 
    [Space]
    public GameObject objBullet;
    public float shotTimeMin;
    public float shotTimeMax;
    public int shotChance;

    [Header("BOSS")]
    public bool isBoss;
    public GameObject objBulletBoss;
    public float timeSpawnBossBullet;
    private float timerBossShot;
    public int shotChanceBoss;

    private void Start()
    {
        if (!isBoss)
        {
            Invoke("OpenFire", Random.Range(shotTimeMin, shotTimeMax));
        }
    }

    private void Update()
    {
        if(isBoss)
        {
            if(Time.time>timerBossShot)
            {
                timerBossShot = Time.time + timeSpawnBossBullet;
                OpenFire();
                OpenFireBoss();
            }
        }
    }

    public void GetDamage(int damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <=0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        LevelController.instance.ScoreInGame(scoreValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetDamage(1);
            Player.instance.GetDamage(1);
        }
        if (collision.tag == "Shield")
        {
            GetDamage(1);
            Player.instance.GetDamageShield(1);
        }
    }

    private void OpenFire()
    {
        if (Random.value < (float)shotChance/100)
        {
            Instantiate(objBullet, transform.position, Quaternion.identity);
        }
    }

    private void OpenFireBoss()
    {
        if(Random.value<(float)shotChanceBoss/100)
        {
            for(int i = -40; i < 40; i+=10)
            {
                Instantiate(objBulletBoss, transform.position, Quaternion.Euler(0, 0, i));
            }
        }
    }
}
