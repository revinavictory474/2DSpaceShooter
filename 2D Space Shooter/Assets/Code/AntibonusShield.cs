using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibonusShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.instance.shieldHealth -= 5;

            if(Player.instance.shieldHealth <= 0)
            {
                Player.instance.shieldHealth = 0;
            }
            Destroy(gameObject);
        }
    }
}
