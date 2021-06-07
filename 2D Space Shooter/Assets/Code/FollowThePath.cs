using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [HideInInspector] public Transform[] waypoints;
    [HideInInspector] public float speedEnemy;
    [HideInInspector] public bool isReturn;
    [HideInInspector] public Vector3[] newPosition;
    private int currentPosition;

    private void Start()
    {
        newPosition = NewPosition(waypoints);
        transform.position = newPosition[0];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition[currentPosition], speedEnemy * Time.deltaTime);
        if(Vector3.Distance(transform.position, newPosition[currentPosition]) < 0.2f)
        {
            currentPosition++;
            if(isReturn&&Vector3.Distance(transform.position, newPosition[newPosition.Length -1]) < 0.3f)
            {
                currentPosition = 0;
            }
        }

        if (Vector3.Distance(transform.position, newPosition[newPosition.Length - 1]) < 0.2f && !isReturn)
        {
            Destroy(gameObject);
        }
    }

    private Vector3[] NewPosition(Transform[] pathPosition)
    {
        Vector3[] pathPosit = new Vector3[pathPosition.Length];

        for( int i =0; i < waypoints.Length; i++)
        {
            pathPosit[i] = pathPosition[i].position;
        }

        pathPosit = Smooshing(pathPosit);
        pathPosit = Smooshing(pathPosit);
        pathPosit = Smooshing(pathPosit);

        return pathPosit;

    }

    private Vector3[] Smooshing(Vector3[] pathPos)
    {
        Vector3[] newPathPos = new Vector3[(pathPos.Length - 2) * 2 + 2];
        newPathPos[0] = pathPos[0];
        newPathPos[newPathPos.Length - 1] = pathPos[pathPos.Length - 1];

        int j = 1;
        for (int i = 0; i < pathPos.Length - 2; i++)
        {
            newPathPos[j] = pathPos[i] + (pathPos[i + 1] - pathPos[i]) * 0.75f;
            newPathPos[j + 1] = pathPos[i + 1] + (pathPos[i + 2] - pathPos[i + 1]) * 0.25f;
            j += 2;
        }
        return newPathPos;
    }
}
