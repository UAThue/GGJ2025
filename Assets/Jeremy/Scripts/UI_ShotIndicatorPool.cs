using UnityEngine;

public class UI_ShotIndicatorPool : MonoBehaviour
{
	public UI_ShotIndicator[] allIndicators;

	public int currentIndicator;

	public void Shot(ObjectSpawner.spawnShotType shot, float angle, float randOffset)
	{
		allIndicators[currentIndicator].Indicator(shot, angle, randOffset);
		currentIndicator += 1;
		if(currentIndicator== allIndicators.Length)
		{
			currentIndicator = 0;
		}
	}
}
