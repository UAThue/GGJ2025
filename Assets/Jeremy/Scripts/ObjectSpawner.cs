using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public UI_ShotIndicatorPool UIShotIndicatorPool;

    public GameObject spawnSpinner;

    public Transform spawnPosition;
    public GameObject NeedleProjectilePrefab;
    public GameObject BubbleProjectilePrefab;
    public GameObject NeutralProjectilePrefab;
    public enum spawnShotType
	{
        bubble,
        needle,
        neutral
	}

    //Settings for spawn frequency.
    public float currentMinSpawnTime;
    public float currentMaxSpawnTime;

    //Used to increase difficulty
    public float lowestPossibleSpawnTime;
    public float timeBetweenWaveIncreases;
    public float timeBetweenAmountIncreases;

    //Settings for spawning
    private float currentWaveTimer;
    private float nextSpawnTimer;
    private float nextAmountIncreaseTimer;

    //Current difficulty
    private float spawnTime;
    private float currentAmount = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Random.Range(currentMinSpawnTime, currentMaxSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWaveTimer += Time.deltaTime;
        if(currentWaveTimer>=timeBetweenWaveIncreases)
		{
            //Decrease time between wave increases. TODO: BALANCE THIS. 95% is a random decision. Minimum of 3 is a random decision.
            currentWaveTimer = 0;
            timeBetweenWaveIncreases *= 0.95f; 
            if(timeBetweenWaveIncreases<=3)
			{
                timeBetweenWaveIncreases = 3;
			}
            //Increasing waves makes max and min lower. TODO: BALANCE THIS. 95% is a random decision
            currentMinSpawnTime *= 0.95f;
            currentMaxSpawnTime *= 0.95f;
            if(currentMinSpawnTime<= lowestPossibleSpawnTime)
			{
                currentMinSpawnTime = lowestPossibleSpawnTime;
			}
            if(currentMaxSpawnTime <= lowestPossibleSpawnTime)
			{
                currentMaxSpawnTime = lowestPossibleSpawnTime;
			}
        }
        nextSpawnTimer += Time.deltaTime;
        if(nextSpawnTimer>=spawnTime)
		{
            //Spawn somethin;
            //Spin the thing, tell the UI to tell the player its gonna spawn something. Then spawn something (which will need to wait for the UI)
            for(int i = 0; i < currentAmount; i++)
			{
                float randAngle = Random.Range(0, 360);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, randAngle);
                //SPAWN
                int randItem = Random.Range(0, 3);
                switch(randItem)
				{
                    case 0:
                            GameObject.Instantiate(BubbleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.bubble, randAngle);
                        break;
                    case 1:
                            GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.needle, randAngle);
                        break;
                    case 2:
                            GameObject.Instantiate(NeutralProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.neutral, randAngle);
                        break;
                }
            }
            //Reset spawn timer and find a random spawn time
            spawnTime = Random.Range(currentMinSpawnTime, currentMaxSpawnTime);
            nextSpawnTimer = 0;
		}
        nextAmountIncreaseTimer += Time.deltaTime;
        if(nextAmountIncreaseTimer>=timeBetweenAmountIncreases)
		{
            currentAmount += 1;
            nextAmountIncreaseTimer = 0;
		}
    }
}
