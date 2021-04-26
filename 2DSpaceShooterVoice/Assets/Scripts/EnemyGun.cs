using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Controls enemy gun and fires bullet at player
 */
public class EnemyGun : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject EnemyBulletGO;
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGO");
        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);   

        }
    }
}
