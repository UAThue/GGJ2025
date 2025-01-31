using UnityEngine;
using UnityEngine.UI;
public class UI_ShotIndicator : MonoBehaviour
{
    public Image spriteHolder;
    public Image bg;
    public Image arrowIndicator;

    public Sprite bubble;
    public Sprite needle;
    public Sprite neutral;
    public Sprite bunny;

    private float timer;
    public bool go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowIndicator.color = new Color(1, 1, 1, 0);
        go = false;
        spriteHolder.color = new Color(1, 1, 1, 0);
        bg.enabled = false;
    }

    public void Indicator(ObjectSpawner.spawnShotType shot, float angle, float offsetLeftRight)
	{
        go = true;
        timer = 0;
        switch (shot)
		{
            case ObjectSpawner.spawnShotType.bubble:
                spriteHolder.sprite = bubble;
                spriteHolder.color = Color.white;
                bg.color = new Color(0.2f, 0.2f, 1, 1);
                arrowIndicator.color = new Color(0.2f, 0.2f, 1, 1);

                break;
            case ObjectSpawner.spawnShotType.needle:
                spriteHolder.sprite = needle;
                spriteHolder.color = Color.white;
                bg.color = new Color(1f, 0.2f, 0.2f, 1);
                arrowIndicator.color = new Color(1f, 0.2f, 0.2f, 1);

                break;
            case ObjectSpawner.spawnShotType.neutral:
                spriteHolder.sprite = neutral;
                spriteHolder.color = Color.white;
                bg.color = new Color(0.2f, 1, 0.2f, 1);
                arrowIndicator.color = new Color(0.2f, 1, 0.2f, 1);

                break;
            case ObjectSpawner.spawnShotType.bunny:
                spriteHolder.sprite = bunny;
                spriteHolder.color = Color.white;
                bg.color = new Color(1, 1, 0.2f, 1);
                arrowIndicator.color = new Color(1f, 1, 0.2f, 1);

                break;
        }
        arrowIndicator.fillAmount = 0;
        bg.enabled = true;
        this.transform.localEulerAngles = new Vector3(0, 0, angle);
        arrowIndicator.rectTransform.anchoredPosition = new Vector2(arrowIndicator.rectTransform.anchoredPosition.x, offsetLeftRight*67);
        spriteHolder.rectTransform.anchoredPosition = new Vector2(spriteHolder.rectTransform.anchoredPosition.x, offsetLeftRight * 67); 
        bg.rectTransform.anchoredPosition = new Vector2(bg.rectTransform.anchoredPosition.x, offsetLeftRight * 67);
    }

	public void Update()
	{
	if(go==true)
		{
            timer += Time.deltaTime;
            arrowIndicator.fillAmount = timer;
            if (timer >= 1)
            {
                arrowIndicator.fillAmount = 0;
                arrowIndicator.color = new Color(1, 1, 1, 0);
                go = false;
                spriteHolder.color = new Color(1, 1, 1, 0);
                bg.enabled = false;
            }
		}
	}
}
