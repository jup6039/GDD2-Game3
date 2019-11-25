using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLimeClump : MonoBehaviour
{
    // Fields
    public GameObject spawnObject;
    public GameObject triggerObject;

    private Vector3 spawnPosition; // This wil be the trigger object's original position
    private Quaternion spawnRotation;
    private bool spawnTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = triggerObject.transform.position;
        spawnRotation = triggerObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTrigger)
        {
            Instantiate(spawnObject, spawnPosition, spawnRotation);
            spawnTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == triggerObject.GetComponent<Collider>())
        {
            spawnTrigger = true;
            Debug.Log("exit");
        }
    }
}
