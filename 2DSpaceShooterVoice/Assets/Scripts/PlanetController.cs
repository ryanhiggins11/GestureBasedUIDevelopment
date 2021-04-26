using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Controls planets movements
 */
public class PlanetController : MonoBehaviour
{
    public GameObject[] planets;
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        availablePlanets.Enqueue(planets[0]);
        availablePlanets.Enqueue(planets[1]);
        availablePlanets.Enqueue(planets[2]);
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MovePlanetDown()
    {
        if (availablePlanets.Count == 0)
            return;
        GameObject aplanet = availablePlanets.Dequeue();
        aplanet.GetComponent<Planet>().isMoving = true;
    }
    void enquePlanet()
    {
        foreach(GameObject aplanet in planets)
        {
            if((aplanet.transform.position.y < 0) && (!aplanet.GetComponent<Planet>().isMoving))
            {
                aplanet.GetComponent<Planet>().ResetPos();
                availablePlanets.Enqueue(aplanet);
            }
        }
    }
}
