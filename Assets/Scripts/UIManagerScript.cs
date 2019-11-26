using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("clicked!");
        SceneManager.LoadScene("Level1");
    }
}
