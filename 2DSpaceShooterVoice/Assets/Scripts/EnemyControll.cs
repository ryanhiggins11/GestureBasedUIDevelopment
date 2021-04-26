using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Controls enemy, Updates Score, Controls enemy Position, Collisions and animations also coded here
 */
public class EnemyControll : MonoBehaviour
{
    GameObject scoreUITextGO;
    float speed;
    public GameObject ExplosionGO;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("TextScoreTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);
        transform.position = pos;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerShipTag" || collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
