using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    private GameObject player;
    public GameObject[] statTexts;
    //0 --> range


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        statTexts[0].GetComponent<Text>().text = player.GetComponent<Player>().getRange().ToString();
        statTexts[1].GetComponent<Text>().text = player.GetComponent<Player>().getSpeed().ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
