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
    public Transform winScreen;
    public Transform checklist;
    //public Button restartButton;

    // private stuff
    private Scene currentScene;
    private string sceneName;
    private bool didWin;

    // Toggles
    public Toggle sugarToggle;
    public Toggle flourToggle;
    public Toggle milkToggle;
    public Toggle eggsToggle;

    // Start is called before the first frame update
    void Start()
    {
        // Set toggles
        sugarToggle.isOn = false;
        flourToggle.isOn = false;
        milkToggle.isOn = false;
        eggsToggle.isOn = false;

        didWin = false;
        areaCollider = this.GetComponent<Collider>();
        //restartButton.onClick.AddListener(RestartScene);
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        gameOverMenu.gameObject.SetActive(false);
        checklist.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // constantly go through array of game objects and check to see if any are inside the objective area
        for (int i = 0; i < 5; i++)
        {
            if (areaCollider.bounds.Contains(objectArray[i].transform.position))
            {
                if (incorrectArray.Contains(objectArray[i]))    // game over if object in array is one of objects in incorrect array
                {
                    checklist.gameObject.SetActive(false);
                    gameOverMenu.gameObject.SetActive(true);
                }
                else if (objectArray[i].name == "sugar")        // checkmarks are checked when the ingredient is in the area
                {
                    sugarToggle.isOn = true;
                }
                else if (objectArray[i].name == "flour")
                {
                    flourToggle.isOn = true;
                }
                else if (objectArray[i].name == "milk")
                {
                    milkToggle.isOn = true;
                }
                else if (objectArray[i].name == "eggs")
                {
                    eggsToggle.isOn = true;
                }
            }
            else
            {
                sugarToggle.isOn = false;       // checkmarks unchecked if ingredient left the area
                flourToggle.isOn = false;
                milkToggle.isOn = false;
                eggsToggle.isOn = false;
            }
        }

        if (sugarToggle.isOn == true && flourToggle.isOn == true && milkToggle.isOn == true && eggsToggle.isOn == true)
        {
            didWin = true;      // win if all checkmarks are checked (all ingredients are within the objective area)
            winScreen.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("r"))      // restart game
        {
            RestartScene();
        }

        if (didWin == true && Input.GetKeyDown("escape"))       // exit the game upon winning
        {
            Application.Quit();
        }
    }

    // Reset Game Scene
    void RestartScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
        gameOverMenu.gameObject.SetActive(false);
        Debug.Log("scene restarted");
    }
}
