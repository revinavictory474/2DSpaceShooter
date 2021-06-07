using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public GameObject[] playerShips;
    public EnemyWaves[] enemyWaves;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for ( int i = 0; i< enemyWaves.Length; i++)
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart,enemyWaves[i].wave));
        }
    }

    private IEnumerator CreateEnemyWave(float delay, GameObject wave)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(wave); 
    }
}
