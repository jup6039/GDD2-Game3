using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Fields
    public GameObject objectiveHandler;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        // This is currently the first level. Intended to be the Start Screen by the end of next sprint
        //LoadFirstLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads next scene, if it exists
    public void LoadNextLevel()
    {
        currentIndex++;
        if(currentIndex <= 1)
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
        currentIndex = 0;
        SceneManager.LoadScene(currentIndex);
    }
}
