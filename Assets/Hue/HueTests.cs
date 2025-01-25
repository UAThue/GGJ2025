using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class HueTests : MonoBehaviour
{

    public GameObject bubble;
    public float radius = 5.0f;
    public int numObjects = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<GameObject> rings;
        rings = GameManager.instance.CreateRingOfObjects(transform.position, radius, numObjects, bubble, gameObject);
        GameManager.instance.LinkRingOfGameObjects(rings);
    }

    // Update is called once per frame
    void Update()
    {      

    }
}
