using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves 
{
    public float timeToStart;
    public GameObject wave;
    public bool isLastWave;
}

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public GameObject[] playerShips;
    public EnemyWaves[] enemyWaves;
    public bool isFinal;

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
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart,enemyWaves[i].wave, enemyWaves[i].isLastWave));
        }
    }

    private void Update()
    {
        if(isFinal == true && GameObject.FindGameObjectsWithTag("Enemy").Length ==0 )
        {
            Debug.Log("WIN");
        }
        if(Player.instance == null)
        {
            Debug.Log("LOSE");
        }
    }

    private IEnumerator CreateEnemyWave(float delay, GameObject wave, bool final)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(wave);
        if (final == true)
            isFinal = true;
    }
}
