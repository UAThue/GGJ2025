using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]


public class PopOnTouch : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the bubble
        Bubble theBubble = collision.gameObject.GetComponent<Bubble>();
        
        // If it is one
        if (theBubble != null )
        {
            // Pop it
            theBubble.Pop();
            Destroy(this.gameObject);
        }

    }

}
