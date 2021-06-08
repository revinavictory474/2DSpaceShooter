using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int playerHealth = 1;
    public GameObject objShield;
    public int shieldHealth = 1;

    private Slider sliderHPPlayer;
    private Slider sliderHPShield;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        sliderHPPlayer = GameObject.FindGameObjectWithTag("HPPlayer").GetComponent<Slider>();
        sliderHPShield = GameObject.FindGameObjectWithTag("HPShield").GetComponent<Slider>();
    }

    private void Start()
    {
        sliderHPPlayer.value = (float)playerHealth / 10;

        if(shieldHealth != 0)
        {
            objShield.SetActive(true);
            sliderHPShield.value = (float)shieldHealth / 10;
        }
        else
        {
            objShield.SetActive(false);
            sliderHPShield.value = 0;
        }
    }

    public void GetDamage(int damage)
    {
        playerHealth -= damage;
        sliderHPPlayer.value = (float)playerHealth / 10;
        if (playerHealth <= 0)
            Destruction();
    }

    public void GetDamageShield(int damage)
    {
        shieldHealth -= damage;
        sliderHPShield.value = (float)shieldHealth / 10;
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
