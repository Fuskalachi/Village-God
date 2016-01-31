using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextScene : MonoBehaviour {

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}