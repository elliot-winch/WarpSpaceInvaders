using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

	public void Begin()
    {
        SceneManager.LoadScene("Main");
    }
}
