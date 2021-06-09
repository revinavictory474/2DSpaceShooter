using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    public ShootingSettings shootingSettings;
    [Space]
    public GameObject objEnemy;
    public Transform[] waypoints;
    private FollowThePath followThePath;
    public int countInWave;
    public float speedEnemy;
    public float timeSpawnEnemy;
    public bool isReturn;
    [Header("Test wave")]
    public bool isTest;
    private Enemy _enemy;
   
    void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }

    private IEnumerator CreateEnemyWave()
    {
        for (int i =0; i < countInWave; i++)
        {
            GameObject newEnemy = Instantiate(objEnemy, objEnemy.transform.position, Quaternion.identity);
            followThePath = newEnemy.GetComponent<FollowThePath>();
            followThePath.waypoints = waypoints;
            followThePath.speedEnemy = speedEnemy;
            followThePath.isReturn = isReturn;

            _enemy = newEnemy.GetComponent<Enemy>();
            _enemy.shotChance = shootingSettings.shotChance;
            _enemy.shotTimeMin = shootingSettings.shotTimeMin;
            _enemy.shotTimeMax = shootingSettings.shotTimeMax;

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

    private void OnDrawGizmos()
    {
        NewPosition(waypoints);
    }

    private void NewPosition(Transform[] path)
    {
        Vector3[] pathPosition = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathPosition[i] = path[i].position;
        }

        pathPosition = Smooshing(pathPosition);
        pathPosition = Smooshing(pathPosition);
        pathPosition = Smooshing(pathPosition);

        for (int i = 0; i<pathPosition.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPosition[i], pathPosition[i + 1]);

        }
    }

    private Vector3[] Smooshing(Vector3[] pathPos)
    {
        Vector3[] newPathPos = new Vector3[(pathPos.Length - 2) * 2 + 2];
        newPathPos[0] = pathPos[0];
        newPathPos[newPathPos.Length - 1] = pathPos[pathPos.Length-1];

        int j = 1;
        for(int i =0; i<pathPos.Length - 2; i++)
        {
            newPathPos[j] = pathPos[i] + (pathPos[i + 1] - pathPos[i]) * 0.75f;
            newPathPos[j + 1] = pathPos[i + 1] + (pathPos[i + 2] - pathPos[i + 1]) * 0.25f;
            j += 2;
        }
        return newPathPos;
    }
}
