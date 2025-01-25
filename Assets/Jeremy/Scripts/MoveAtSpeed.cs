using UnityEngine;

public class MoveAtSpeed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed;
    private float delay = 0;
    private float destroy = 0;


    // Update is called once per frame
    void Update()
    {

        delay += Time.deltaTime;
        if(delay>1)
		{
            transform.localPosition += transform.forward * Time.deltaTime * moveSpeed;
        }
        destroy += Time.deltaTime;
        if(destroy>10)
		{
            Destroy(this.gameObject);
		}
    }
}
