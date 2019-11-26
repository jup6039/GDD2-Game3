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
    //public GameObject[] objectArray = new GameObject[8];
    public List<GameObject> ingredients;
    private List<GameObject> toggles;
    //public GameObject[] incorrectArray = new GameObject[4];
    public Transform gameOverMenu;
    public Transform winScreen;
    public Transform checklist;
    public GameObject toggleDefault;

    // private stuff
    private Scene currentScene;
    private string sceneName;
    private bool didWin;

    // Toggles
    /*public Toggle sugarToggle;
    public Toggle flourToggle;
    public Toggle milkToggle;
    public Toggle eggsToggle;*/

    // Start is called before the first frame update
    void Start()
    {
        didWin = false;
        areaCollider = this.GetComponent<Collider>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        gameOverMenu.gameObject.SetActive(false);
        checklist.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        toggles = new List<GameObject>();

        for (int i = 0; i < ingredients.Count; i++)
        {
            // Create ingredient name texts
            GameObject ingredientName = new GameObject(ingredients[i].name);
            ingredientName.transform.SetParent(checklist);

            RectTransform ingredientTransform = ingredientName.AddComponent<RectTransform>();
            ingredientTransform.anchoredPosition = new Vector2(0, 20 * -i);

            Text ingredientText = ingredientName.AddComponent<Text>();
            ingredientText.text = ingredients[i].name;
            ingredientText.font = ArialFont;
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

            //RectTransform toggleTransform = ingredientToggle.AddComponent<RectTransform>();
            //ingredientName.anchoredPosition = new Vector2(0, 20 * -i);

            /*Toggle actualToggle = ingredientToggle.AddComponent<Toggle>();
            actualToggle.isOn = false;
            actualToggle.interactable = false;
            actualToggle.graphic = toggleGraphic;
            actualToggle.targetGraphic = toggleBackGraphic;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        // constantly go through array of game objects and check to see if any are inside the objective area
        /*
        for (int i = 0; i < 8; i++)
        {
            if (areaCollider.bounds.Contains(objectArray[i].transform.position))
            {
                //if (incorrectArray.Contains(objectArray[i]))    // game over if object in array is one of objects in incorrect array
                //{
                //    checklist.gameObject.SetActive(false);
                //    gameOverMenu.gameObject.SetActive(true);
                //}
                //else 
                if (objectArray[i].name == "Avocado")        // checkmarks are checked when the ingredient is in the area
                {
                    sugarToggle.isOn = true;
                    objectArray[i].SetActive(false);
                }
                else if (objectArray[i].name == "Tomato")
                {
                    flourToggle.isOn = true;
                    objectArray[i].SetActive(false);
                }
                else if (objectArray[i].name == "Onion")
                {
                    milkToggle.isOn = true;
                    objectArray[i].SetActive(false);
                }
                else if (objectArray[i].name == "Chip")
                {
                    eggsToggle.isOn = true;
                    objectArray[i].SetActive(false);
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
        */
        foreach (GameObject food in ingredients)
        {
            if(areaCollider.bounds.Contains(food.transform.position))
            {
                foreach(GameObject toggle in toggles)
                {
                    if (food.name == toggle.name)
                    {
                        toggle.GetComponent<Toggle>().isOn = true;
                    }

                    food.SetActive(false);
                    ingredients.Remove(food);
                    Destroy(food);
                }
            }
        }

        if (ingredients.Count == 0)
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Lime") || other.name.Contains("lime"))
        {
            checklist.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(true);
        }
    }
}
