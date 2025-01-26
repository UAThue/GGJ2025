using UnityEngine;

public class GrowFadeAndDie : MonoBehaviour
{

    public float startScale;
    public float endScale;
    public float startAlpha;
    public float endAlpha;

    public float lifespan;
    private float currentScale;
    private float currentAlpha;
    // Add audio as just an Audio Source
    private Color fadeColor = Color.white;
    public AudioSource dontDieUntilDone;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScale = startScale;
        currentAlpha = startAlpha;
        //Destroy(gameObject.transform.parent.gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        float scaleRange = endScale - startScale;
        float changePerSecond = scaleRange / lifespan;

        currentScale = Mathf.MoveTowards(currentScale, endScale, changePerSecond * Time.deltaTime);
        transform.localScale = Vector3.one * currentScale;

        float alphaRange = endAlpha - startAlpha;
        changePerSecond = alphaRange / lifespan;

        currentAlpha = Mathf.MoveTowards(currentAlpha, endAlpha, -changePerSecond * Time.deltaTime);
        fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, currentAlpha);
        GetComponent<TMPro.TextMeshProUGUI>().color = fadeColor;

        if (dontDieUntilDone != null)
        {
            if (currentScale == endScale && dontDieUntilDone.isPlaying == false) Destroy(transform.parent.gameObject);
		}
		else
		{
            if (currentScale == endScale) Destroy(transform.parent.gameObject);
        }
    }
}
