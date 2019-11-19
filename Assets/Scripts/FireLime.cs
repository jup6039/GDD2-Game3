using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLime : MonoBehaviour
{
    // Variables
    public GameObject lime;
    public float speed = 200f;
    public GameObject player;

    private float timer = 0;
    private bool toFire = false;
    private bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameObject.GetComponent<BoxCollider>().)

        if (!timerActive && toFire)
        {
            GameObject limeProjectile = Instantiate(lime, transform.position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0))) as GameObject;
            //limeProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            limeProjectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
            timerActive = true;
        }

        if(timerActive)
        {
            timer += Time.deltaTime;
            if(timer >= 1.5f)
            {
                timer = 0;
                timerActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
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
