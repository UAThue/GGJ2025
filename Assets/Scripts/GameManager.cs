using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> CreateRingOfObjects (Vector3 center, float radius, int numberOfObjects, GameObject prefab, GameObject parent=null)
    {
        // Create a list to hold the objects
        List<GameObject> theRing = new List<GameObject>();

        // For each of the objects
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Find the angle for object i
            float angle = i * Mathf.PI *  2 / numberOfObjects ; 

            // Trig to find the opposite (z) and hypotenuse (x)
            float x = Mathf.Cos( angle ) * radius;
            float z =  Mathf.Sin( angle ) * radius;
            Vector3 offset = new Vector3(x, z, 0);

            // Relative to center passed in
            Vector3 position = center + offset;
            Debug.Log(position);
            
            // Instantiate the objects and add to list
            theRing.Add(Instantiate(prefab, position, Quaternion.identity, parent.transform));
        }

        // Send back our list
        return theRing; 
    }

    public void LinkRingOfGameObjects ( List<GameObject> ring )
    {
        // link first to last
        SafeLinkSprings(ring[0], ring.Last<GameObject>());


        // Then, for 1 to the end, link to previous 
        for (int i=1; i<ring.Count; i++)
        {
            SafeLinkSprings(ring[i], ring[i - 1]);
        }
    }


    public void SafeLinkSprings(GameObject one,  GameObject two)
    {
        if (one == null) 
        {
            Debug.LogError("ERROR: GameObject " + one + " does not exist");
            return;
        }
        if (two == null)
        {
            Debug.LogError("ERROR: GameObject " + two + " does not exist");
            return;
        }

        // Get the rigidbodys or add if needed
        Rigidbody2D rbOne = one.GetComponent<Rigidbody2D>();
        if (rbOne == null) rbOne = one.AddComponent<Rigidbody2D>();
        Rigidbody2D rbTwo = two.GetComponent<Rigidbody2D>();
        if (rbTwo == null) rbTwo = two.AddComponent<Rigidbody2D>();

        // Get the spring joint
        SpringJoint2D springJoint = one.GetComponent<SpringJoint2D>();
        if (springJoint == null) springJoint = one.AddComponent<SpringJoint2D>();

        // Link one to two
        springJoint.connectedBody = rbTwo;
        
        // Activate joint
        springJoint.enabled = true;
    }

}
