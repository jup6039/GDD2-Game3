using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Fields
    public GameObject objectiveHandler;
    public int currentIndex;
    public int sceneCount; //Set this in the inspector based on how many levels there are

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentIndex = scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads next scene, if it exists
    public void LoadNextLevel()
    {
        currentIndex++;
        if(currentIndex <= sceneCount)
        {
            SceneManager.LoadScene(currentIndex);
        }
        else
        {
            LoadFirstLevel();
        }
    }

    // Loads the first scene. Meant to replace RestartScene in the ObjectiveTracker
    public void LoadFirstLevel()
    {
        currentIndex = 1;
        SceneManager.LoadScene(currentIndex);
    }
}
