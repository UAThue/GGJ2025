using UnityEngine;

public class DestroywhenDone : MonoBehaviour
{
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>2)
		{
            Destroy(this.gameObject);
		}
    }
}
