using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    static ScoreTracker instance;

    public static ScoreTracker Instance
    {
        get
        {
            return instance;
        }
    }

    public Text scoreUIText;

    public string scoreFilePath = "Assets/Resources/scores.txt";

    int score = 0;
    bool acceptingScores = true;

    void Start () {
        instance = this;
	}

    public void IncrementScore()
    {
        if (acceptingScores)
        {
            score++;

            scoreUIText.text = "Score: " + score;
        }

    }

    public void SaveScore()
    {
        acceptingScores = false;

        StreamWriter writer = new StreamWriter(scoreFilePath, true);
        writer.WriteLine(score);
        writer.Close();
    }
}
