﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonus : MonoBehaviour
{
    public GameObject[] objectPlanets;
    public float timePlanetSpawn;
    public float speedPlanets;
    List<GameObject> planetList = new List<GameObject>();
   
    void Start()
    {
        StartCoroutine(PlanetsCreation());
    }

    private IEnumerator PlanetsCreation()
    {
        for ( int i = 0; i<objectPlanets.Length; i++)
        {
            planetList.Add(objectPlanets[i]);
        }
        yield return new WaitForSeconds(7);

        while (true)
        {
            int random = Random.Range(0, planetList.Count);
            GameObject newPlanet = Instantiate(planetList[random], new Vector2(Random.Range(PlayerMove.instance.borders.minX, PlayerMove.instance.borders.maxX),
                PlayerMove.instance.borders.maxY * 1.5f), Quaternion.Euler(0, 0, Random.Range(-25, 25)));

            planetList.RemoveAt(random);

            if (planetList.Count == 0)
            {
                for (int i = 0; i < objectPlanets.Length; i++)
                {
                    planetList.Add(objectPlanets[i]);
                }
            }
            newPlanet.GetComponent<ObjectMove>().speed = speedPlanets;

            yield return new WaitForSeconds(timePlanetSpawn);
        }
    }
}