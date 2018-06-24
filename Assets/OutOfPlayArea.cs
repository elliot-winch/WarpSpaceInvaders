using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPlayArea : MonoBehaviour {

    public int numEscapedEnemiesBeforeGameOver = 10;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            collider.GetComponent<EnemyHealth>().Destroyed();

            numEscapedEnemiesBeforeGameOver--;

            Debug.Log(numEscapedEnemiesBeforeGameOver);

            if(numEscapedEnemiesBeforeGameOver <= 0)
            {
                Debug.Log("Game over");
                //GameOver
            }
        }
    }
}
