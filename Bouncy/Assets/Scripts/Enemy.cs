using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyID;


    // Start is called before the first frame update
    void Start()
    {
        switch (enemyID)
        {
            case "001":

                break;

            case "002":
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
