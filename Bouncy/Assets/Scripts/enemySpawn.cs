using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    // [0] enemy 1

    private Vector3 randomPos;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++) {
            randomPos.x = Random.Range(-12.0f, 12.0f);
            randomPos.y = Random.Range(-12.0f, 12.0f);

            GameObject enemy = Instantiate(enemies[0],transform.position + randomPos,Quaternion.identity) as GameObject;
            enemy.transform.SetParent(transform);
        }
    }

    public int getIndex(int scale) {
        //scale will be the parameter for the round that the game is on.
        int num = 0;
        if (scale < 10) {
            num = (int)Random.Range(0f, 1f);
        }
        return num;
    }

    public int getRound() {
        return this.round;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
