using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject enemyHealthBar;
    private Vector3 healthbarPos;

    // Start is called before the first frame update
    void Start()
    {
        healthbarPos.y = 0.8f;
        healthbarPos.x = -0.5f;
        GameObject hb = Instantiate(enemyHealthBar, transform.position + healthbarPos, Quaternion.identity);
        hb.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
