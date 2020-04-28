using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,

    Follow, 

    Die
};

public class Enemy : MonoBehaviour
{

    public GameObject enemyHealthBar;
    private GameObject hb;
    public GameObject target;
    private GameObject enemyS;

    private Vector3 healthbarPos;

   

    
    public float health;
    private float maxHealth;

    //for enemy movement
    public EnemyState currState = EnemyState.Wander;
    public float sight;
    public float speed;
    private bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemyS = GameObject.FindGameObjectWithTag("enemySpawner");


        maxHealth = 8f;
        health = maxHealth;
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

        switch (currState) {
            case (EnemyState.Wander):
                Wander();
            break;
            case (EnemyState.Follow):
                Follow();
               break;
            case (EnemyState.Die):
                
               break;

        }

        if (isPlayerInRange(sight) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if(!isPlayerInRange(sight) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }

        hb.transform.localScale = new Vector3((health / maxHealth), hb.transform.localScale.y, hb.transform.localScale.z);
        if (health <= 0) {
            currState = EnemyState.Die;
            Destroy(gameObject);
            enemyS.gameObject.SendMessage("enemyDeath");
        }

    }

    private bool isPlayerInRange(float range) { 
        return Vector3.Distance(transform.position, target.transform.position) <= range;
    }

    private IEnumerator chooseDirection(bool urgent)
    {
        chooseDir = true;
        if (urgent)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3.RotateTowards(transform.position,new Vector3(0,0,0),speed * Time.deltaTime,0.0f);
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            randomDir = new Vector3(0, 0, Random.Range(0, 360));
            Quaternion nextRotation = Quaternion.Euler(randomDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        }
        
        
        chooseDir = false;
    }

    void Wander() {
        if (!chooseDir) {
            StartCoroutine(chooseDirection(false));
        }

        transform.position += -transform.right * speed * Time.deltaTime;

        if (isPlayerInRange(sight)) {
            currState = EnemyState.Follow;
        }

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) > 15) {
            StartCoroutine(chooseDirection(true));
        }
    }

    void Follow() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
