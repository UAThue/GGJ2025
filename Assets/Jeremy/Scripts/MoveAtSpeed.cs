using UnityEngine;

public class MoveAtSpeed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool move = true;
    public float moveSpeed;
    private float delay = 0;
    private float destroy = 0;

    public Rigidbody2D myMover;


    // Update is called once per frame
    void Update()
    {
    delay += Time.deltaTime;
        if (delay > 1)
        {
            if (move == true)
            {
                if (myMover != null)
                {
                    myMover.AddForce(myMover.transform.right * -moveSpeed * Time.deltaTime);
                }
            }
        }
        destroy += Time.deltaTime;
        if (destroy > 15 && move == true)
        {
            Destroy(this.gameObject);
        }
    }
}
