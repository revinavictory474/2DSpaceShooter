using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonus : MonoBehaviour
{
    public GameObject[] objBonus;
    public float timeBonusSpawn;
    public GameObject[] objectPlanets;
    public float timePlanetSpawn;
    public float speedPlanets;
    List<GameObject> planetList = new List<GameObject>();
    List<GameObject> bonusList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(PlanetsCreation());
        StartCoroutine(BonusCreation());
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
                PlayerMove.instance.borders.maxY * 2.0f), Quaternion.Euler(0, 0, Random.Range(-25, 25)));

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

    private IEnumerator BonusCreation()
    {
        for (int i = 0; i < objBonus.Length; i++)
        {
            bonusList.Add(objBonus[i]);
        }
        yield return new WaitForSeconds(7);


        while (true)
        {
            int random = Random.Range(0, bonusList.Count);

            yield return new WaitForSeconds(timeBonusSpawn);

            GameObject newBonus = Instantiate(objBonus[random], new Vector2(Random.Range(PlayerMove.instance.borders.minX, PlayerMove.instance.borders.maxX),
                PlayerMove.instance.borders.maxY * 1.5f), Quaternion.identity);


           // bonusList.RemoveAt(random);

            if (bonusList.Count == 0)
            {
                for (int i = 0; i < objBonus.Length; i++)
                {
                    bonusList.Add(objBonus[i]);
                }
            }

            yield return new WaitForSeconds(timeBonusSpawn);
        }

    }
}
