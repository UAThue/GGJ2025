using UnityEngine;
using UnityEngine.UI;
public class BubbleSpriteColor : MonoBehaviour
{
    public SpriteRenderer bubbleSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Color newCol = Color.Lerp(Color.cyan, Color.magenta, Random.Range(0.15f, 0.85f));
        newCol.a = Random.Range(0.85f, 0.95f);
        bubbleSprite.color = newCol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
