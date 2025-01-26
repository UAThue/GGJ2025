using System;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerText != null)
        {
            float secondsSinceStart = Time.time - GameManager.instance.gameStartTime;
            TimeSpan ts = TimeSpan.FromSeconds(secondsSinceStart);
            timerText.text = ts.ToString(@"mm\:ss\:fff");
        }
    }
}
