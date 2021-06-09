using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Player.instance.playerHealth += 5;

            Destroy(gameObject);
        }
    }
}
