using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleRing : Pawn
{
    [Header("Prefabs")]
    public GameObject bubblePrefab;
    public GameObject cat;
    public GameObject catShadow;
    public Sprite catUp;
    public Sprite catNeutral;
    public Sprite catDown;
    [Header("Options")]
    public float radius = 5.0f;
    public int numObjects = 10;
    public float bubbleOutwardForce = 1.0f;
    public float bubbleThickness = 0.5f;
    [HideInInspector] public bool stickyRing = false;

    public LineRenderer_Rainbow rainbowRing;

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
            if (ring[i] != null)
            {
                currentCenter += ring[i].transform.position;
            }
        }
        if (ring.Count > 0)
        {
            currentCenter /= ring.Count;
        }
        else
        {
            currentCenter = Vector3.zero;
        }
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

            // Flip/Animate Cat
            if (moveVector.x > 0.1f)
            {
                cat.GetComponent<SpriteRenderer>().flipX = true;
                catShadow.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveVector.x < -0.1f)
            {
                cat.GetComponent<SpriteRenderer>().flipX = false;
                catShadow.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (moveVector.y > 0.1f)
            {
                cat.GetComponent<SpriteRenderer>().sprite = catUp;
            }
            else if (moveVector.y < -0.1f)
            {
                cat.GetComponent<SpriteRenderer>().sprite = catDown;
            } else
            {
                cat.GetComponent<SpriteRenderer>().sprite = catNeutral;
            }


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

            //  Scale the bubbles by a random tiny amount (0.9 to 1.1) to make more appealing
            // Note: Removed because bubbles are now invisible for ring - just line renderer used
            // Vector3 thicknessOffset = Vector3.one * Random.Range(-0.1f, 0.1f);
            Vector3 thicknessOffset = Vector3.zero;

            // Scale the bubble;
            theBubbleObject.transform.localScale = (Vector3.one * bubbleThickness) + thicknessOffset;

            // Add to list
            Bubble theBubble = theBubbleObject.GetComponent<Bubble>();
            theBubble.owningRing = this;
            theBubble.hadAnOwningRing = true;
            theBubble.isMeStickToOthers = stickyRing;
            theBubble.joint.distance = bubbleThickness;
            theRing.Add(theBubble);
        }

        //JEREMY: Adding transforms for linerenderer test
        Transform[] transformArray = new Transform[theRing.Count+1];
        for (int i = 0; i < theRing.Count; i++)
		{
            transformArray[i] = theRing[i].transform;
		}
        //Add the first again
        transformArray[theRing.Count] = theRing[0].transform;
        rainbowRing.SetUpLine(transformArray);

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
        }

        // Clear the list 
        ring.Clear();

        // Hide the cat
        cat.SetActive(false);

        // Wait a bit and then load the GameOver Screen
        Invoke("LoadGameOverScreen", 1.5f); // Yep. I used Invoke. No, I am not proud of it.

        rainbowRing.Done();
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOverScene");
        GameManager.instance.SetVolume(0.5f);
    }

}
