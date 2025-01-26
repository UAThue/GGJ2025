using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class RandomCatNoises : MonoBehaviour
{

    private AudioSource audioSource;
    public List<AudioClip> catNoises;
    public float chancePerFrameDrawToMew = 0.0005f;
    public Vector2 volumeRange = Vector2.one;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (Random.value < chancePerFrameDrawToMew)
            {
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(catNoises[Random.Range(0, catNoises.Count)], Random.Range(volumeRange.x, volumeRange.y));
            }
        }
    }

}
