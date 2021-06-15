using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance = null;
    public int playerHealth;
    public GameObject objShield;
    public int shieldHealth = 1;

    public float timerBonus = 5.0f;
    //public float currentTimerBonusShot;
    //public float timerBonusShot = 15.0f;

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
        sliderHPPlayer.value = (float)playerHealth / 15;

        if(shieldHealth != 0)
        {
            objShield.SetActive(true);
            sliderHPShield.value = (float)shieldHealth / 6;
        }
        else
        {
            objShield.SetActive(false);
            sliderHPShield.value = 0;
        }
    }

    private void Update()
    {
        DecreaseTime();
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

    private void DecreaseTime()
    {
        if (PlayerShooting.instance.curPuwerLevelGuns > 1)
        {
            timerBonus -= Time.deltaTime;

            if (timerBonus <= 0)
            {
                PlayerShooting.instance.curPuwerLevelGuns--;

                Debug.Log("Decrease gun");

                timerBonus = 5;
            }
        }
    }

    public void Destruction()
    {
        Destroy(gameObject);
    }
}
