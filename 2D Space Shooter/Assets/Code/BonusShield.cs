using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Player.instance.shieldHealth += 5;
            Player.instance.objShield.SetActive(true);

            Destroy(gameObject);
        }
    }
}
