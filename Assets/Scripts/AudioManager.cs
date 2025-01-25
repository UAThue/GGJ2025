using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip pop;

    public void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
