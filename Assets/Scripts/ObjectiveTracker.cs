using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ObjectiveTracker : MonoBehaviour
{
    // Variables
    public Collider areaCollider;
    public GameObject[] objectArray = new GameObject[5];
    public GameObject[] incorrectArray = new GameObject[1];
    public Transform gameOverMenu;
    //public Button restartButton;
    public Scene currentScene;
    
    // Start is called before the first frame update
    void Start()
    {
        areaCollider = this.GetComponent<Collider>();
        gameOverMenu.gameObject.SetActive(false);
        //restartButton.onClick.AddListener(RestartScene);
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (areaCollider.bounds.Contains(objectArray[i].transform.position))
            {
                if (incorrectArray.Contains(objectArray[i]))
                {
                    gameOverMenu.gameObject.SetActive(true);
                }
            }
        }
    }

    // Reset Game Scene
    /*void RestartScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
        gameOverMenu.gameObject.SetActive(false);
        Debug.Log("scene restarted");
    }*/
}
