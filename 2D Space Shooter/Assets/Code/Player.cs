using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int playerHealth = 1;
    public GameObject objShield;
    public int shieldHealth = 1;

    private void Start()
    {
        if(shieldHealth != 0)
        {
            objShield.SetActive(true);
        }
        else
        {
            objShield.SetActive(false);
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GetDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
            Destruction();
    }

    public void GetDamageShield(int damage)
    {
        shieldHealth -= damage;

        if(shieldHealth<=0)
        {
            objShield.SetActive(false);
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }
}
