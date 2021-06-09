using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private bool isWork;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isWork = true;

            if(PlayerShooting.instance.curPuwerLevelGuns<PlayerShooting.instance.maxPowerLevelGuns)
            {
                PlayerShooting.instance.curPuwerLevelGuns++;
            }
        }
    }
}
