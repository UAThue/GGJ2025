using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class RandomCatNoises : MonoBehaviour
{

    private AudioSource audioSource;
    public List<AudioClip> catNoises;
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
            if (Random.value < 0.001f)
            {
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(catNoises[Random.Range(0, catNoises.Count)]);
            }
        }
    }

}
