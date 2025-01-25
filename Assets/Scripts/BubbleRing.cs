using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BubbleRing : Pawn
{
    [Header("Prefabs")]
    public GameObject bubblePrefab;
    public GameObject cat;
    [Header("Options")]
    public float radius = 5.0f;
    public int numObjects = 10;
    public float bubbleOutwardForce = 1.0f;
    public float bubbleThickness = 0.5f;
    [HideInInspector] public bool stickyRing = false;

    // Private Vars
    [HideInInspector] public List<Bubble> ring;
    private Vector3 currentCenter; // Currently the center of the rings - find it every update

    void Start()
    {
        // Create the objects
        ring = CreateRingOfBubbles(transform.position, radius, numObjects, bubblePrefab, gameObject);
        // Link them
         LinkRingOfGameObjects(ring);
    }

    void Update()
    {
        if (cat != null)
        {
            cat.transform.position = currentCenter;
        }
    }

    public void FindCenter()
    {
        // Find average position - that is our center
        currentCenter = Vector3.zero;
        for (int i = 0; i < ring.Count; i++)
        {
            currentCenter += ring[i].transform.position;
        }
        currentCenter /= ring.Count;
    }

    private void FixedUpdate()
    {
        // Find the center
        FindCenter(); 

        // Each bubble needs to move in direction based on input PLUS the force to center it
        MoveRings(moveVector);

        // Rotate 
        RotateRings(rotation);
    }

    public void RotateRings(float angle)
    {
        // For every bubble
        for (int i = 0; i < ring.Count; i++)
        {
            ring[i].transform.RotateAround(currentCenter, Vector3.forward, angle * rotationSpeed * Time.deltaTime);
        }
        
    }
        public void MoveRings(Vector3 direction)
    {
        // Move every bubble
        for (int i = 0; i < ring.Count; i++)
        {
            // Start with movement force
            Vector3 moveVector = direction.normalized * moveForce;

            // Add outward bubble force
            Vector3 vectorToCenter = ring[i].transform.position - currentCenter;
            vectorToCenter.Normalize();
            vectorToCenter *= bubbleOutwardForce;
            moveVector += vectorToCenter;
            
            Rigidbody2D rb = ring[i].GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // add vector for our push from center
                rb.AddForce(moveVector, ForceMode2D.Force);
            }
        }
    }

    public List<Bubble> CreateRingOfBubbles(Vector3 center, float radius, int numberOfObjects, GameObject prefab, GameObject parent = null)
    {
        // Create a list to hold the objects
        List<Bubble> theRing = new List<Bubble>();

        // For each of the objects
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Find the angle for object i
            float angle = i * Mathf.PI * 2 / numberOfObjects;

            // Trig to find the opposite (z) and hypotenuse (x)
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 offset = new Vector3(x, z, 0);

            // Relative to center passed in
            Vector3 position = center + offset;

            // Instantiate the objects and add to list
            GameObject theBubbleObject = Instantiate(prefab, position, Quaternion.identity, parent.transform);

            // Scale the bubbles by a random tiny amount (0.9 to 1.1) to make more appealing
            Vector3 thicknessOffset = Vector3.one * Random.Range(-0.1f, 0.1f);

            // Scale the bubble;
            theBubbleObject.transform.localScale = (Vector3.one * bubbleThickness) + thicknessOffset;

            // Add to list
            Bubble theBubble = theBubbleObject.GetComponent<Bubble>();
            theBubble.owningRing = this;
            theBubble.isMeStickToOthers = stickyRing;
            theBubble.joint.distance = bubbleThickness;
            theRing.Add(theBubble);
        }

        // Send back our list
        return theRing;
    }

    public void LinkRingOfGameObjects(List<Bubble> ring)
    {
        // link first to last
        ring[0].SafeLinkSprings(ring[ring.Count-1]);


        // Then, for 1 to the end, link to previous 
        for (int i = 1; i < ring.Count; i++)
        {
            ring[i].SafeLinkSprings(ring[i - 1]);
        }
    }

    public void PopAll()
    {
        for (int i=0; i < ring.Count; i++)
        {
            ring[i].owningRing = null;
            ring[i].Pop();
            ring.RemoveAt(i);
        }
    }

}
