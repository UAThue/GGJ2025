using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]


public class PopOnTouch : MonoBehaviour
{
    public bool wall = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (wall == false)
        {
            // Get the bubble
            Bubble theBubble = collision.gameObject.GetComponent<Bubble>();

            // If it is one
            if (theBubble != null)
            {
                // Pop it
                theBubble.Pop();
                Destroy(transform.parent.gameObject);
            }

            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Destroy(transform.parent.gameObject);
            }
		}
		else
		{
            //WALLS ONLY POP ATTACHED BUBBLES
            // Get the bubble
            Bubble theBubble = collision.gameObject.GetComponent<Bubble>();

            // If it is one
            if (theBubble != null)
            {
                // Pop it
                if (theBubble.isMeStickToOthers == false)
                {
                    theBubble.Pop();
                }
            }
        }
    }
}
