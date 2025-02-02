using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public UI_ShotIndicatorPool UIShotIndicatorPool;

    public GameObject spawnSpinner;

    public Transform spawnPosition;
    public GameObject NeedleProjectilePrefab;
    public float minScaleNeedle;
    public float maxScaleNeedle;
    public GameObject BubbleProjectilePrefab;
    public float minScaleBubble;
    public float maxScaleBubble;
    public GameObject NeutralProjectilePrefab;
    public float minScaleNeutral;
    public float maxScaleNeutral;
    public GameObject bunnyProjectilePrefab;
    public float minScaleBunny;
    public float maxScaleBunny;

    public enum spawnShotType
	{
        bubble,
        needle,
        neutral,
        bunny
	}

    //This adds a very small touch of randomness.
    public float difficulty;
    public float randomWiggleRoomBubble;
    private float currentWiggleRoomBubble;
    public float randomWiggleRoomBird;
    private float currentWiggleRoomBird;
    public float randomWiggleRoomCloud;
    private float currentWiggleRoomCloud;
    public float randomWiggleRoomBunny;
    private float currentWiggleRoomBunny;

    //Keep track of how often things spawn 
    private float spawnBubbleTimer;
    private float spawnBirdTimer;
    private float spawnCloudTimer;
    private float spawnBunnyTimer;


    //Used to separate things
    private float lastAngle = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        difficulty += Time.deltaTime;
        spawnBubbleTimer += Time.deltaTime;
        //EVERY 3 SECONDS  SPAWN A BUBBLE
        if (spawnBubbleTimer - currentWiggleRoomBubble >= 3)
        {
            //RESET TIMER
            spawnBubbleTimer = 0;
            //CHANGE WIGGLE ROOM
            currentWiggleRoomBubble = Random.Range(0, randomWiggleRoomBubble);
            //ALWAYS SPAWN A BUBBLE
            GetNextAngle();
            //Put the spawner in the right spot
            float randOffset = Random.Range(-2, 2);
            spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
            spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
            //Spawn
            GameObject bubbleSpawned = GameObject.Instantiate(BubbleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
            UIShotIndicatorPool.Shot(spawnShotType.bubble, lastAngle, randOffset);
            float bubScale = Random.Range(minScaleBubble, maxScaleBubble);
            bubbleSpawned.transform.localScale = new Vector3(bubScale, bubScale, bubScale);

            //Bubbles change to doubles/triples
            if (difficulty <= 60)
            {
                //Just one bubble.
                //Do nothing
            }
            else if (difficulty <= 120)
            {
                //IN ADDITION, SPAWN SOMETHING ELSE
                GetNextAngle();
                randOffset = Random.Range(-2, 2);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN
                int randItem = Random.Range(0, 3);
                switch (randItem)
                {
                    case 0:
                        bubbleSpawned = GameObject.Instantiate(BubbleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.bubble, lastAngle, randOffset);
                        bubScale = Random.Range(minScaleBubble, maxScaleBubble);
                        bubbleSpawned.transform.localScale = new Vector3(bubScale, bubScale, bubScale);
                        break;
                    case 1:
                        GameObject needleSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
                        float needScale = Random.Range(minScaleNeedle, maxScaleNeedle);
                        needleSpawned.transform.localScale = new Vector3(needScale, needScale, needScale);
                        break;
                    case 2:
                        GameObject neutralSpawned = GameObject.Instantiate(NeutralProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.neutral, lastAngle, randOffset);
                        float neutScale = Random.Range(minScaleNeutral, maxScaleNeutral);
                        neutralSpawned.transform.localScale = new Vector3(neutScale, neutScale, neutScale);
                        break;
                }
            }
            else
            {
                //IN ADDITION, SPAWN TWO SOMETHINGS ELSE
                GetNextAngle();
                randOffset = Random.Range(-2, 2);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN SOMETHING RANDOM
                int randItem = Random.Range(0, 3);
				switch (randItem)
				{
					case 0:
						bubbleSpawned = GameObject.Instantiate(BubbleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
						UIShotIndicatorPool.Shot(spawnShotType.bubble, lastAngle, randOffset);
						bubScale = Random.Range(minScaleBubble, maxScaleBubble);
						bubbleSpawned.transform.localScale = new Vector3(bubScale, bubScale, bubScale);
						break;
					case 1:
						GameObject needleSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
						UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
						float needScale = Random.Range(minScaleNeedle, maxScaleNeedle);
						needleSpawned.transform.localScale = new Vector3(needScale, needScale, needScale);
						break;
					case 2:
						GameObject neutralSpawned = GameObject.Instantiate(NeutralProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
						UIShotIndicatorPool.Shot(spawnShotType.neutral, lastAngle, randOffset);
						float neutScale = Random.Range(minScaleNeutral, maxScaleNeutral);
						neutralSpawned.transform.localScale = new Vector3(neutScale, neutScale, neutScale);
						break;
				}
                //REPEAT
				GetNextAngle();
                randOffset = Random.Range(-2, 2);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN ANOTHER RANDOM THING
                randItem = Random.Range(0, 3);
                switch (randItem)
                {
                    case 0:
                        bubbleSpawned = GameObject.Instantiate(BubbleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.bubble, lastAngle, randOffset);
                        bubScale = Random.Range(minScaleBubble, maxScaleBubble);
                        bubbleSpawned.transform.localScale = new Vector3(bubScale, bubScale, bubScale);
                        break;
                    case 1:
                        GameObject needleSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
                        float needScale = Random.Range(minScaleNeedle, maxScaleNeedle);
                        needleSpawned.transform.localScale = new Vector3(needScale, needScale, needScale);
                        break;
                    case 2:
                        GameObject neutralSpawned = GameObject.Instantiate(NeutralProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                        UIShotIndicatorPool.Shot(spawnShotType.neutral, lastAngle, randOffset);
                        float neutScale = Random.Range(minScaleNeutral, maxScaleNeutral);
                        neutralSpawned.transform.localScale = new Vector3(neutScale, neutScale, neutScale);
                        break;
                }
            }
        }
        //BIRDS START 15 SECONDS IN AND GO EVERY 3.5 SECONDS
        if (difficulty > 16)
        {
            spawnBirdTimer += Time.deltaTime;
            //EVERY 3 SECONDS  SPAWN A BUBBLE
            if (spawnBirdTimer - currentWiggleRoomBird >= 3.5f)
            {
                //RESET TIMER
                spawnBirdTimer = 0;
                //RESET BIRD WIGGLE ROOM
                currentWiggleRoomBird = Random.Range(0, randomWiggleRoomBird);
                //CHOOSE NEW ANGLE AND OFFSET
                GetNextAngle();
                float randOffset = Random.Range(-1, 1);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN BIRD
                GameObject birdSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
                float birdScale = Random.Range(minScaleNeedle, maxScaleNeedle);
                birdSpawned.transform.localScale = new Vector3(birdScale, birdScale, birdScale);
                //ADD A SECOND BIRD AFTER 80 SECONDS AND A THIRD AFTER 160
                if (difficulty > 80)
                {
                    //DO NOT CHOOSE NEW ANGLE. TRYING TO MAKE FLOCKS OF BIRDS
                    randOffset = Random.Range(-2, -1);
                    spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                    //SPAWN BIRD
                    birdSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                    UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
                    birdScale = Random.Range(minScaleNeedle, maxScaleNeedle);
                    birdSpawned.transform.localScale = new Vector3(birdScale, birdScale, birdScale);
                }
                if (difficulty > 160)
                {
                    //DO NOT CHOOSE NEW ANGLE. TRYING TO MAKE FLOCKS OF BIRDS
                    randOffset = Random.Range(1, 2);
                    spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                    //SPAWN BIRD
                    birdSpawned = GameObject.Instantiate(NeedleProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                    UIShotIndicatorPool.Shot(spawnShotType.needle, lastAngle, randOffset);
                    birdScale = Random.Range(minScaleNeedle, maxScaleNeedle);
                    birdSpawned.transform.localScale = new Vector3(birdScale, birdScale, birdScale);
                }
            }
        }

        //CLOUDS START 45 SECONDS IN AND GO EVERY 5 SECONDS
        if (difficulty > 45)
        {
            spawnCloudTimer += Time.deltaTime;
            //EVERY 6 SECONDS  SPAWN A CLOUD
            if (spawnCloudTimer - currentWiggleRoomCloud >= 6.25f)
            {
                //RESET TIMER
                spawnCloudTimer = 0;
                //RESET BIRD WIGGLE ROOM
                currentWiggleRoomCloud = Random.Range(0, randomWiggleRoomCloud);
                //CHOOSE NEW ANGLE AND OFFSET
                GetNextAngle();
                float randOffset = Random.Range(-2, 2);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN BIRD
                GameObject cloudSpawned = GameObject.Instantiate(NeutralProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                UIShotIndicatorPool.Shot(spawnShotType.neutral, lastAngle, randOffset);
                float cloudScale = Random.Range(minScaleNeutral, maxScaleNeutral);
                cloudSpawned.transform.localScale = new Vector3(cloudScale, cloudScale, cloudScale);
            }
        }
        //BUNNIES 1.5 MINUTES IN AND EVERY 12
        if (difficulty > 90)
        {
            spawnBunnyTimer += Time.deltaTime;
            if (spawnBunnyTimer - currentWiggleRoomBunny >= 13f)
            {
                //RESET TIMER
                spawnBunnyTimer = 0;
                //RESET WIGGLE ROOM
                currentWiggleRoomBunny = Random.Range(0, randomWiggleRoomBunny);
                //CHOOSE NEW ANGLE AND OFFSET
                GetNextAngle();
                float randOffset = Random.Range(-2, 2);
                spawnPosition.localPosition = new Vector3(spawnPosition.transform.localPosition.x, randOffset, spawnPosition.transform.localPosition.z);
                spawnSpinner.transform.localEulerAngles = new Vector3(0, 0, lastAngle);
                //SPAWN BUNNY
                GameObject bunnySpawned = GameObject.Instantiate(bunnyProjectilePrefab, spawnPosition.position, spawnPosition.rotation);
                UIShotIndicatorPool.Shot(spawnShotType.bunny, lastAngle, randOffset);
                float bunnyScale = Random.Range(minScaleBunny, maxScaleBunny);
                bunnySpawned.transform.localScale = new Vector3(bunnyScale, bunnyScale, bunnyScale);
            }
        }
    }

    public void GetNextAngle()
	{
        float randAngle = Random.Range(25, 335);
        lastAngle += randAngle;
        if (lastAngle > 360)
        {
            lastAngle -= 360;
        }
    }
}
