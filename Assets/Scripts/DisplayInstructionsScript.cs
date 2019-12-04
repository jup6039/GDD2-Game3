using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayInstructionsScript : MonoBehaviour
{
    public GameObject backButton;
    public GameObject instructionsButton;
    public GameObject startButton;
    public GameObject controlsText;
    public GameObject instructionsText;
    public GameObject textBackground;

    // Start is called before the first frame update
    void Start()
    {
        instructionsButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        startButton.SetActive(false);
        instructionsText.SetActive(true);
        controlsText.SetActive(true);
        textBackground.SetActive(true);
        backButton.SetActive(true);
        instructionsButton.SetActive(false);
    }
}
