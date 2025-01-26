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
    public AudioSource menuMusic;
    private float menuMusicTargetVolume=0.5f;

    [Header("Particles and Sounds")]
    public GameObject featherExplosion;
    public GameObject bubbleExplosion;
    public AudioClip featherSquawk;
    public AudioClip bubblePop;
    public AudioClip bubbleLink;


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
        if(menuMusic.volume!=menuMusicTargetVolume)
		{
            menuMusic.volume = Mathf.MoveTowards(menuMusic.volume, menuMusicTargetVolume, Time.deltaTime);
		}
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

    public void SetVolume(float volume)
	{
        menuMusicTargetVolume = volume;
	}
}
