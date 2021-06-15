using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public static Bonus instance;
    public bool isWork;
    public float timerCurrent;
    public float timerBonus = 5.0f;

    private void Update()
    {
        //DecreaseTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (PlayerShooting.instance.curPuwerLevelGuns < PlayerShooting.instance.maxPowerLevelGuns)
            {
                PlayerShooting.instance.curPuwerLevelGuns++;
                Debug.Log("gun ++");
                Destroy(gameObject);
            }
        }
    }

    //private void DecreaseTime()
    //{
    //    if (PlayerShooting.instance.curPuwerLevelGuns > 1)
    //    {
    //        timerBonus -= Time.deltaTime;

    //        if (timerBonus <= 0)
    //        {
    //            PlayerShooting.instance.curPuwerLevelGuns--;

    //            Debug.Log("Decrease gun");
    //        }
    //    }
    //}
}
