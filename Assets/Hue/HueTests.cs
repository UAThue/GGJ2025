using System.Collections.Generic;
using UnityEngine;

public class HueTests : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject player = FindFirstObjectByType<BubbleRing>().cat;
            GameManager.instance.AddScore(1, player.transform.position);            
        }
    }
}
