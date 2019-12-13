using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Fields
    //public GameObject objectiveHandler;
    public int currentIndex;
    public int levelAmount; //Set this in the inspector based on how many levels there are. Do not include the start and end menus.
                         // So if there are 8 levels, this should be set to 8 for every scene

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
        if(currentIndex <= levelAmount)
        {
            SceneManager.LoadScene(currentIndex);
        }
    }

    // Loads the first scene. Meant to replace RestartScene in the ObjectiveTracker
    public void LoadFirstLevel()
    {
        currentIndex = 1;
        SceneManager.LoadScene(currentIndex);
    }
}
