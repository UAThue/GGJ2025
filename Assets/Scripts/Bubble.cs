using UnityEngine;
[RequireComponent (typeof(Collider2D), typeof(Rigidbody2D))]

public class Bubble : MonoBehaviour
{
    public bool isMeStickToOthers;
    private DistanceJoint2D joint;

    void Awake()
    {
        // Make sure we have a collider, set it to enabled and NOT a trigger (so we get a link point)
        Collider2D collider = gameObject.GetComponent<Collider2D>();
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


}
