using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ObjectiveTracker : MonoBehaviour
{
    // Variables
    public GameObject sceneHandler;
    public GameObject bgMusic;
    public GameObject loseMusic;
    public GameObject levelCompMusic;
    public Collider areaCollider;
    public List<GameObject> ingredients;
    private List<GameObject> toggles;
    public Transform gameOverMenu;
    public Transform levelCompleteMenu;
    public Transform winScreen;
    public Transform checklist;
    public GameObject toggleDefault;

    // private stuff
    private Scene currentScene;
    private string sceneName;
    private bool didWin;
    private bool nextLevelScreen;

    // Private Music Stuff
    private bool singleClipPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        didWin = false;
        nextLevelScreen = false;
        areaCollider = this.GetComponent<Collider>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        gameOverMenu.gameObject.SetActive(false);
        checklist.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
        levelCompleteMenu.gameObject.SetActive(false);
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        toggles = new List<GameObject>();

        for (int i = 0; i < ingredients.Count; i++)
        {
            // Create ingredient name texts
            GameObject ingredientName = new GameObject(ingredients[i].name);
            ingredientName.transform.SetParent(checklist);

            RectTransform ingredientTransform = ingredientName.AddComponent<RectTransform>();
            ingredientTransform.anchorMin = new Vector2(0, 1);
            ingredientTransform.anchorMax = new Vector2(0, 1);
            ingredientTransform.anchoredPosition = new Vector2(35, 20 * -i - 75);

            Text ingredientText = ingredientName.AddComponent<Text>();
            ingredientText.text = ingredients[i].name;
            ingredientText.font = ArialFont;
            ingredientText.fontSize = 22;
            ingredientText.color = Color.black;

            // Create toggles
            GameObject ingredientToggle = Instantiate(toggleDefault);
            ingredientToggle.name = ingredients[i].name;
            ingredientToggle.transform.SetParent(checklist);
            ingredientToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, (20 * -i) - 50);
            ingredientToggle.GetComponent<Toggle>().isOn = false;
            ingredientToggle.GetComponent<Toggle>().interactable = false;

            // Add toggles to list
            toggles.Add(ingredientToggle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // constantly go through array of game objects and check to see if any are inside the objective area
        foreach (GameObject food in ingredients)
        {
            if(areaCollider.GetComponent<MeshRenderer>().bounds.Contains(food.transform.position))
            {
                foreach(GameObject toggle in toggles)
                {
                    if (food.name == toggle.name)
                    {
                        toggle.GetComponent<Toggle>().isOn = true;
                        food.SetActive(false);
                        ingredients.Remove(food);
                        Destroy(food);
                        break;
                    }
                }
                break;
            }
        }

        if (ingredients.Count == 0)
        {
            didWin = true;      // win if all checkmarks are checked (all ingredients are within the objective area)
            if(sceneHandler.GetComponent<SceneHandler>().currentIndex < sceneHandler.GetComponent<SceneHandler>().levelAmount)
            {
                nextLevelScreen = true;
                levelCompleteMenu.gameObject.SetActive(true);
                bgMusic.GetComponent<AudioSource>().Stop();
                if(!singleClipPlayed)
                {
                    levelCompMusic.GetComponent<AudioSource>().Play();
                    singleClipPlayed = true;
                }
            }
            else
            {
                SceneManager.LoadScene("WinMenu");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (Input.GetKeyDown("c") && nextLevelScreen)
        {
            sceneHandler.GetComponent<SceneHandler>().LoadNextLevel();
        }

        if (Input.GetKeyDown("r"))      // restart game
        {
            gameOverMenu.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(false);
            levelCompleteMenu.gameObject.SetActive(false);
            //sceneHandler.GetComponent<SceneHandler>().LoadFirstLevel();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Lime") || other.name.Contains("lime"))
        {
            checklist.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(true);
            bgMusic.GetComponent<AudioSource>().Stop();
            if(!singleClipPlayed)
            {
                loseMusic.GetComponent<AudioSource>().Play();
                singleClipPlayed = true;
            }
        }
    }
}
