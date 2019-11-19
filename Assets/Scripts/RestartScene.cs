using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class RestartScene : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // loads current scene
        Debug.Log("scene restarted");
    }

}