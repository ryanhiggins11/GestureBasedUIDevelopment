using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * This script controls stars which can be seen when the game starts
 */

public class Star : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

    }
}
