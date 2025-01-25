using UnityEngine;

public class UI_ShotIndicatorPool : MonoBehaviour
{
	public UI_ShotIndicator[] allIndicators;

	public int currentIndicator;

	public void Shot(ObjectSpawner.spawnShotType shot, float angle)
	{
		allIndicators[currentIndicator].Indicator(shot, angle);
		currentIndicator += 1;
		if(currentIndicator== allIndicators.Length)
		{
			currentIndicator = 0;
		}
	}
}
