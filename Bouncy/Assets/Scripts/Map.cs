using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject shrub;

    private Vector3 randShrubPos;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 25; i++) {
            randShrubPos.x = Random.Range(-20.0f, 20.0f);
            randShrubPos.y = Random.Range(-20.0f, 20.0f);
            GameObject shb = Instantiate(shrub, randShrubPos,Quaternion.identity) as GameObject;
            shb.transform.SetParent(transform);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
