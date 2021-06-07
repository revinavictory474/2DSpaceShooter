using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;
    public float speedEnemy;
    public bool isReturn;
    public Vector3[] newPosition;
    private int currentPosition;

    private void Start()
    {
        newPosition = NewPosition(waypoints);
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
        return pathPosit;

    }


}
