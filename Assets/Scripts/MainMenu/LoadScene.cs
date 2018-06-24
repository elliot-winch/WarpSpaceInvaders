using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadWithName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
