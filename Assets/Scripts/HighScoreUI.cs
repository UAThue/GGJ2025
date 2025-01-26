using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float secondsSinceGameStart = Time.time - GameManager.instance.gameStartTime;
        int whoa = (int)secondsSinceGameStart;
        GameManager.instance.score *= whoa;

        UpdateHighScore();   


        score.text = "Your Score: " + GameManager.instance.score;
        highScore.text = "High Score: " + GameManager.instance.highScore;

    }

    void UpdateHighScore()
    {
        if (GameManager.instance.score > GameManager.instance.highScore)
        {
            GameManager.instance.highScore = GameManager.instance.score;
            DoSomethingCool();
        }
       
    }

    void DoSomethingCool()
    {
        // TODO: Do something cool if we get the high score

        score.color = Color.yellow;
        score.outlineColor = Color.black;
        highScore.color = Color.yellow;
        highScore.outlineColor = Color.black;
    }

    public void ResetScores()
    {
        GameManager.instance.score = 0;
    }
}
