using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class RandomizeSoundPitch : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
    }

}
