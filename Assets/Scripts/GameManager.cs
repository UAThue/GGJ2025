using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Data")]
    public int score;
    public int highScore;
    public float gameStartTime;
    public float numberOfBubblesCollected;
    public float numberOfBirdsDefeated;

    [Header("Prefabs")]
    public ScoreObject scoreObjectPrefab;

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
        scoreObject.scoreText.text = amount.ToString();
        score += amount;
    }
   
    public void StartGame()
    {
        score = 0;
        gameStartTime = Time.time;
    }
}
