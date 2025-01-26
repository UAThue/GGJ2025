using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Data")]
    public int score=1;
    public int highScore;
    public float gameStartTime;
    public float pointsPerSecondSurvived;
    //public float numberOfBubblesCollected;
    //public float numberOfBirdsDefeated;

    [Header("Prefabs")]
    public ScoreObject scoreObjectPrefab;

    private ScoreTimer scoreDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore (int amount, Vector3 location)
    {
        ScoreObject scoreObject = Instantiate(scoreObjectPrefab, location, Quaternion.identity) as ScoreObject;
        scoreObject.scoreText.text = "+1x";
        score += amount;
        if(scoreDisplay == null)
		{
            scoreDisplay = GameObject.FindAnyObjectByType<ScoreTimer>();
		}
        scoreDisplay.multiplier.text = string.Format("x{0}", score);
    }
   
    public void StartGame()
    {
        score = 1;
        gameStartTime = Time.time;
    }
}
