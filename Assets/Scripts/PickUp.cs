using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Variables

    // Public
    public GameObject player;
    public GameObject pickUp;
    public GameObject playerCamera;
    public float grabDist;
    public string pickupTag;

    public float holdFactor = 0.5f;

    // Private
    private Vector3 oldPosition;
    private Vector3 position;
    private Vector3 forward;

    private RaycastHit hit;

    private int counter;
    private float holdDist;
    public float minHoldDist;
    private bool holding;

    // Timer
    private float timer;
    private float startTime = 0.0f;
    private float maxTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        counter = 0;
        pickupTag = "Pickup";
    }

    // Update is called once per frame
    void Update()
    {

        forward = playerCamera.transform.forward;

        Color _color = new Color(0, 0, 20.0f);
        Debug.DrawLine(player.transform.position, 10 * (player.transform.position + player.transform.forward), _color);

        Color _color2 = new Color(1.0f, 0, 0);
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (grabDist * forward), _color2);

        Color _color3 = new Color(0, 1.0f, 0);
        Debug.DrawLine(pickUp.transform.position, playerCamera.transform.position + (2 * forward), _color3);

        if (Input.GetMouseButtonDown(0))
        {
            /*if ((pickUp.transform.position - (playerCamera.transform.position + (2 * forward))).magnitude < 2 * pickUp.GetComponent<pickUpCollider>().radius)
            {
                Debug.Log("Pick Up");

                holding = !holding;

                if (!holding)
                {
                    Vector3 moveVec = -oldPosition + position;
                    pickUp.GetComponent<Rigidbody>().velocity = moveVec;
                }
            }
            else
            {
                Debug.Log("Don't Pick Up");
            }*/

            // Check for raycast within the player's grab distance
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, grabDist) && !holding)
            {
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == pickupTag)
                {
                    holding = true;

                    pickUp = hit.collider.gameObject;
                    pickUp.GetComponent<Rigidbody>().isKinematic = true;

                    oldPosition = pickUp.transform.position;

                    holdDist = hit.distance;
                    if (holdDist < minHoldDist)
                    {
                        holdDist = minHoldDist;
                    }
                }
                else
                {
                    Debug.Log("Not Pick-up-able");
                }
            }
            else if (holding)
            {
                Vector3 moveVec = -oldPosition + position;
                pickUp.GetComponent<Rigidbody>().isKinematic = false;
                pickUp.GetComponent<Rigidbody>().velocity = moveVec;

                holding = false;

                // OPTION 2 = NO OBJECT HOLD
                // pickUp.SetActive(true);

                Debug.Log("Put Down");
            }
            else
            {
                Debug.Log("No Hit");
            }
        }

        if (holding)
        {
            position = player.transform.position + (holdDist * forward);
            position.y += holdFactor;

            if (Input.GetMouseButton(1))
            {
                timer += Time.deltaTime;
                if (timer >= maxTime)
                {
                    timer = maxTime;
                }

                Debug.Log(timer);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                holding = false;
                pickUp.GetComponent<Rigidbody>().isKinematic = false;
                pickUp.GetComponent<Rigidbody>().velocity = player.transform.forward * timer * 10.0f;
                timer = startTime;

                Debug.Log("Up");
            }
            else
            {
                // OPTION 1 = HOLD OBJECT TO SIDE
                position += player.transform.right;
                Debug.Log("Whatevs");
            }

            pickUp.GetComponent<Rigidbody>().MovePosition(position);
            //pickUp.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            // OPTION 2 = NO OBJECT HOLD
            // pickUp.transform.position = position;
            // pickUp.SetActive(false);





            // OLD TESTS/ OTHER WAYS TO DO MOVEMENT
            //pickUp.transform.position = position;

            //Vector3 moveVec = -oldPosition + position;

            //pickUp.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //pickUp.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        if (counter == 20)
        {
            oldPosition = position;
            counter = 0;
        }

        counter++;
    }
}
