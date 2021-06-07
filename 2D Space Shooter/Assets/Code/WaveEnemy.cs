using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    public GameObject objEnemy;
    public Transform[] waypoints;
    private FollowThePath followThePath;
    public int countInWave;
    public float speedEnemy;
    public float timeSpawnEnemy;
    public bool isReturn;
    [Header("Test wave")]
    public bool isTest;
   
    void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }

    private IEnumerator CreateEnemyWave()
    {
        for (int i =0; i<countInWave; i++)
        {
            GameObject newEnemy = Instantiate(objEnemy, objEnemy.transform.position, Quaternion.identity);
            followThePath = newEnemy.GetComponent<FollowThePath>();
            followThePath.waypoints = waypoints;
            followThePath.speedEnemy = speedEnemy;
            followThePath.isReturn = isReturn;

            newEnemy.SetActive(true);
            yield return new WaitForSeconds(timeSpawnEnemy);
        }

        if(isTest)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(CreateEnemyWave());
        }

        if (!isReturn)
            Destroy(gameObject);
    }
}
