using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonuses : MonoBehaviour
{
    //array for planets prefab to be spawned
    public GameObject[] ObjPlanets;
    // time between planets spawn
    public float TimePlanetSpawn;
    // moving speed of planets
    public float SpeedPanets;
    //planets list
    // planets cannot repeats
    List<GameObject> planetsList = new List<GameObject>();

    private void Start()
    {
        // start PlanetGeneration as a coroutine
        StartCoroutine(PlanetCreation());
    }

    IEnumerator PlanetCreation()
    {
        //fill the list with planets
        for (int i = 0; i < ObjPlanets.Length; i++)
        {
            planetsList.Add(ObjPlanets[i]);
        }

        //wait 7 sec after game started
        yield return new WaitForSeconds(7);
        // create planets
        while (true)
        {
            // select a random planet from the list
            int randomIndex = Random.Range(0, planetsList.Count);
            //create an instance of the planet? taking into account limits of the player's movement width
            //planet will be created above the camera's visibility
            //planets will move at an angle in the range of -25 to 25
            GameObject newPlanet = Instantiate(planetsList[randomIndex],
            new Vector2(Random.Range(PlayerMoving.instance.borders.MinX, PlayerMoving.instance.borders.MaxX),
            PlayerMoving.instance.borders.MaxY * 1.5f),
            Quaternion.Euler(0, 0, Random.Range(-25, 25)));

            //remove selected planet from the list
            planetsList.RemoveAt(randomIndex);

            // if the list is empty fill again
            if (planetsList.Count == 0)
            {
                for (int i = 0; i < ObjPlanets.Length; i++)
                {
                    planetsList.Add(ObjPlanets[i]);
                }
            }

            // on the created planet we find the component MovingObjects and set the speed of moving
            newPlanet.GetComponent<ObjMoving>().Speed = SpeedPanets;

            //every TimePlanetSpawn seconds
            yield return new WaitForSeconds(TimePlanetSpawn);
        }
    }
}
