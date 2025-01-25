using UnityEngine;

public class RandomBubbleWarble : MonoBehaviour
{
    // The x,y for perlin noise
    private float x = 0;
    private float y = 0;
    public float scale = 0.001f;
    public float maxWarble = 0.5f;
   
    private Vector3 originalScale;
    private Vector3 offsetScale = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Save original scale
        originalScale = transform.localScale;

        // random y
        y = Random.Range(0.0f, 2048.0001f);
        x = Random.Range(0.0f, 2048.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.PerlinNoise(x * scale, y * scale );
        offsetScale = new Vector3( value, value, value ) * maxWarble;
        transform.localScale = originalScale + offsetScale;

        x++; 
    }
}
