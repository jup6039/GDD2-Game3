using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InstructionsBackScript : MonoBehaviour
{
    public GameObject backButton;
    public GameObject startButton;
    public GameObject instructionsButton;
    public GameObject controlsText;
    public GameObject instructionsText;
    public GameObject textBackground;

    // Start is called before the first frame update
    void Start()
    {
        backButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        startButton.SetActive(true);
        instructionsButton.SetActive(true);
        instructionsText.SetActive(false);
        textBackground.SetActive(false);
        controlsText.SetActive(false);
        backButton.SetActive(false);
    }
}
