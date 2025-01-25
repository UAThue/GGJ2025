using UnityEngine;
[RequireComponent (typeof(Collider2D), typeof(Rigidbody2D))]

public class Bubble : MonoBehaviour
{
    public bool isMeStickToOthers;
    [HideInInspector] public BubbleRing owningRing = null;
    [HideInInspector] public DistanceJoint2D joint;
    [HideInInspector] public Collider2D collider;
    public GameObject popParticle;

    void Awake()
    {
        // Make sure we have a collider, set it to enabled and NOT a trigger (so we get a link point)
        collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = true;
        collider.isTrigger = false;

        // Get our own spring joint
        joint = gameObject.GetComponent<DistanceJoint2D>();
        if (joint == null) joint = gameObject.AddComponent<DistanceJoint2D>();
    }

    void Update()
    {
        
    }
    public void SafeLinkSprings(Bubble target)
    {
        if (target == null)
        {
            Debug.LogError("ERROR: GameObject " + target + " does not exist");
            return;
        }

        // Get the rigidbody of target or add if needed
        Rigidbody2D rb = target.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) rb = target.gameObject.AddComponent<Rigidbody2D>();

        // Link our spring joint to target's rigidbody
        joint.connectedBody = rb;

        // Activate joint
        joint.enabled = true;
    }



    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        // If we hit a bubble
        Bubble otherBubble = collision.gameObject.GetComponent<Bubble>();

        if (otherBubble != null)
        {
            // And we stick to bubbles
            if (isMeStickToOthers)
            {
                // Link the joint to the bubble we are connecting to
                SafeLinkSprings(otherBubble);

                // Set distance based on size of this bubble! so we stick to edge?
                joint.autoConfigureDistance = false;
                joint.enableCollision = true;
                joint.maxDistanceOnly = true;
                joint.distance = Vector3.Distance(transform.position, collision.GetContact(0).point) + Vector3.Distance(otherBubble.transform.position, collision.GetContact(0).point);

                // Stop trying to stick to others (but they can stick to us)
                isMeStickToOthers = false;
            }
        }
    }

    public void Pop()
    {
        //TODO: In the future, maybe, if we are part of a ring, we should close the ring instead of releasing the down the chain. 
        if (owningRing != null)
        {
            // Remove from ring, too.
            owningRing.PopAll();
        }
        else
        {
            // Turn off collision
            collider.enabled = false;
            joint.enabled = false;

            //Particles and prepare to destroy this bubble when the animation ends - for now, destroy
            GameObject particles = Instantiate<GameObject>(popParticle, transform.position, transform.rotation);
            Destroy(particles, 0.2f);

            // Play sound
            float pitchShift = Random.Range(-1f, 1f);

            // Destroy this object
            Destroy(this.gameObject);
        }
    }
}
