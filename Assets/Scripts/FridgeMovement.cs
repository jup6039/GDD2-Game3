using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMovement : MonoBehaviour
{
    //Variables
    public float xMovement;
    public float yMovement;
    public float zMovement; // These 3 are how much each frame the object will move
    public float reverseTimer; // The timer that determines when the movement of the object will reverse

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= reverseTimer)
        {
            timer = 0;
            xMovement = -xMovement;
            yMovement = -yMovement;
            zMovement = -zMovement;
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (xMovement * Time.deltaTime),
            gameObject.transform.position.y + (yMovement * Time.deltaTime), 
            gameObject.transform.position.z + (zMovement * Time.deltaTime));
    }
}
