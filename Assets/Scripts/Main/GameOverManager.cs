using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    //Singleton class
    static GameOverManager instance;

    public static GameOverManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Text livesUIText;
    private int lives = 10;

    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = Mathf.Max(0, value);

            //update UI
            livesUIText.text = "Lives: " + lives;

            if(lives <= 0)
            {
                StartCoroutine(GameOver());
            }
        }
    }

    //For the game over state
    public GameObject enemyParent;


    private void Start()
    {
        if(instance != null)
        {
            Debug.LogError("GameOverManager Error: There should be only one GameOverManager");
        }

        instance = this;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            collider.GetComponent<EnemyHealth>().Destroyed();

            Lives--;

        }
    }

    private IEnumerator GameOver()
    {
        ScoreTracker.Instance.SaveScore();

        foreach (EnemyHealth e in enemyParent.GetComponentsInChildren<EnemyHealth>())
        {
            e.Destroyed();
        }

        enemyParent.GetComponent<EnemySpawner>().StopAllCoroutines();

        yield return new WaitForSeconds(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver"); 
    }
}
