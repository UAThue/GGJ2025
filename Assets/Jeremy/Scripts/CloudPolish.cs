using UnityEngine;

public class CloudPolish : MonoBehaviour
{
    public Camera cameraZoom;
    public GameObject[] cloudsLeft;
    public GameObject leftCloudMaster;
    public GameObject[] cloudsRight;
    public GameObject rightCloudMaster;

    public AudioClip whoosh;
    public AudioSource source;

    public float speedTotal;
    public float cloudSpeed;
    private float randomizer = 0.0075f;
    private float cameraLerper;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraZoom.orthographicSize = 9;
        source.PlayOneShot(whoosh);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetRight = rightCloudMaster.transform.position;
        targetRight.x += 1000;
        rightCloudMaster.transform.position = Vector3.MoveTowards(rightCloudMaster.transform.position, targetRight, speedTotal * Time.deltaTime);
        Vector3 targetLeft = leftCloudMaster.transform.position;
        targetLeft.x -= 1000;
        leftCloudMaster.transform.position = Vector3.MoveTowards(leftCloudMaster.transform.position, targetLeft, speedTotal * Time.deltaTime);
        foreach(GameObject leftCloud in cloudsLeft)
		{
            randomizer += 0.075f*Time.deltaTime;
            targetLeft = leftCloud.transform.position;
            targetLeft.x -= 1000;
            leftCloud.transform.position = Vector3.MoveTowards(leftCloud.transform.position, targetLeft, cloudSpeed * randomizer * Time.deltaTime);
        }
        foreach (GameObject rightCloud in cloudsRight)
        {
            randomizer += 0.075f * Time.deltaTime;
            targetRight = rightCloud.transform.position;
            targetRight.x += 1000;
            rightCloud.transform.position = Vector3.MoveTowards(rightCloud.transform.position, targetRight, cloudSpeed * randomizer * Time.deltaTime);
        }
        if(cameraZoom.orthographicSize!=8)
		{
            cameraLerper += Time.deltaTime/3;
            cameraZoom.orthographicSize = Mathf.SmoothStep(9, 8, cameraLerper);
		}
    }
}
