using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject enemyHealthBar;
    private GameObject enemyS;
    private Vector3 healthbarPos;
    private GameObject hb;
    public float health;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyS = GameObject.FindGameObjectWithTag("enemySpawner");


        maxHealth = 8f;
        health = 5f;
        healthbarPos.y = 0.8f;
        healthbarPos.x = -0.5f;
        hb = Instantiate(enemyHealthBar, transform.position + healthbarPos, Quaternion.identity);
        hb.transform.SetParent(transform);
    }

    public void takeDamage(float dmg) {
        if (dmg <= health)
        {
            health -= dmg;
        }
        else {
            health = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hb.transform.localScale.Set((health / maxHealth), hb.transform.localScale.y, hb.transform.localScale.z);
        if (health <= 0) {
            Destroy(gameObject);
            enemyS.gameObject.SendMessage("enemyDeath");
        }
    }
}
