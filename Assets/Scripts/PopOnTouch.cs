using UnityEngine;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]


public class PopOnTouch : MonoBehaviour
{
    public bool wall = false;
    public int pointValue = 1;

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
                if (theBubble.isMeStickToOthers == false)
                {
                    if (theBubble.hadAnOwningRing == false)
                    {
                        GameManager.instance.AddScore(pointValue, transform.position);
                    }
                }

                if (transform.parent != null)
                {
                    Squawk();
                    Destroy(transform.parent.gameObject);
                }
            }

            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Squawk();
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

    public void Squawk()
    {
        // Poof and squawl
        if (GameManager.instance.featherExplosion != null)
        {
            GameObject particles = Instantiate<GameObject>(GameManager.instance.featherExplosion, transform.position, transform.rotation);
        }
        if (GameManager.instance.featherSquawk != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.instance.featherSquawk, transform.position);
        }
    }
}
