using System;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI multiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multiplier.text = "1x";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerText != null)
        {
            float secondsSinceStart = Time.time - GameManager.instance.gameStartTime;
            //TimeSpan ts = TimeSpan.FromSeconds(secondsSinceStart);
            //timerText.text = ts.ToString(@"mm\:ss\:fff");
            int whoa = (int)secondsSinceStart;
            timerText.text = whoa.ToString();
        }
    }
}
