using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLimeDespawn : MonoBehaviour
{
    // Variables
    public GameObject lime; // Passed in prefab
    public float speed = 1000f; // Speed of the limes. With a mass of 1, going over 1000 yields strange results. Not recommended
    public GameObject player; // Player to check with for trigger box
    public float timerCheck = .001f; // The lower this is, the more frequently limes fire
    public bool useTriggerBox = true; // If true, will check for a collision box before firing. Otherwise, continuously fires limes endlessly
    public float areaWidth = 0;
    public float areaHeight = 0; // Height and width for where the limes will spawn
    public float despawnTimeVal = 0; // If you want to change the despawn time from the basic 6 seconds

    private float timer = 0;
    private bool toFire = false;
    private bool timerActive = false;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (useTriggerBox)
        {
            if (!timerActive && toFire)
            {
                spawnPos = new Vector3(Random.Range(transform.position.x, transform.position.x + areaWidth),
                    Random.Range(transform.position.y, transform.position.y + areaHeight), transform.position.z);
                GameObject limeProjectile = Instantiate(lime, spawnPos, Quaternion.identity) as GameObject;
                //limeProjectile.transform.rotation = Random.rotation;
                limeProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                timerActive = true;
            }
        }
        else
        {
            if (!timerActive)
            {
                spawnPos = new Vector3(Random.Range(transform.position.x, transform.position.x + areaWidth),
                    Random.Range(transform.position.y, transform.position.y + areaHeight), transform.position.z);

                GameObject limeProjectile = Instantiate(lime, spawnPos, Quaternion.identity) as GameObject;
                limeProjectile.AddComponent<DespawnTimer>();
                if(despawnTimeVal > 0)
                    limeProjectile.GetComponent<DespawnTimer>().despawnTime = despawnTimeVal;
                //limeProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                limeProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                timerActive = true;
            }
        }

        if (timerActive)
        {
            timer += Time.deltaTime;
            if (timer >= timerCheck)
            {
                timer = 0;
                timerActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            toFire = true;
            Debug.Log("enter");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            toFire = false;
            Debug.Log("exit");
        }
    }
}
