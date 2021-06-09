using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingSettings : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] public int shotChance;
    [SerializeField] public float shotTimeMin;
    [SerializeField] public float shotTimeMax;

}
