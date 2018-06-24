using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class LoadScores : MonoBehaviour {

    public string scoresFilePath = "Assets/Resources/scores.txt";

    public void Start()
    {
        StreamReader reader = new StreamReader(scoresFilePath);

        GetComponent<Text>().text = "Scores:\n\n" + reader.ReadToEnd();

        reader.Close();
    }
}
