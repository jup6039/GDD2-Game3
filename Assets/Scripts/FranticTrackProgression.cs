using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FranticTrackProgression : MonoBehaviour
{
    // Variables
    public GameObject franticTrackMain;
    private bool trackStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            if(!trackStarted)
            {
                franticTrackMain.GetComponent<AudioSource>().Play();
                trackStarted = true;
            }
        }
    }
}
