using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject player;
    private GameObject enemyS;
    private Vector2 distance;
    private float range;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyS = GameObject.FindGameObjectWithTag("enemySpawner");
        range = player.GetComponent<Player>().range;
    }

    void Update()
    {
        distance.x = Mathf.Abs(player.transform.position.x - transform.position.x);
        distance.y = Mathf.Abs(player.transform.position.y - transform.position.y);

        if (distance.x > range || distance.y > range) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")) {
            enemyS.gameObject.SendMessage("enemyDeath");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
