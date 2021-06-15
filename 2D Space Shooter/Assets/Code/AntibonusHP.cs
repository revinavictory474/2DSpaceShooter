using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibonusHP : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.instance.playerHealth -= 5;
            if(Player.instance.playerHealth<=0)
            {
                Player.instance.Destruction();
            }
            Destroy(gameObject);
        }
    }
}
