using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    //A variable to hold a copy of the lime prefab for easy access
    public GameObject limePrefab;

    //A list of GameObjects, each one placed in the scene so they hold specified positions in the scene where incredients can be spawned 
    public List<GameObject> positionsToSpawnAt;

    //A hardcoded list of spawnable ingredient prefabs to test if method is working
    public List<GameObject> listOfSpawnables;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnIngredients(listOfSpawnables, positionsToSpawnAt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnLime(new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

    //Method to spawn ingredients at start of level in positions based on ingredients needed in level 
    void SpawnIngredients(List<GameObject> requiredIngredients, List<GameObject> positions)
    {
        for (int i = 0; i < requiredIngredients.Count; i++)
        {
            Instantiate(requiredIngredients[i], positions[i].transform.position, Quaternion.identity);
        }
    }

    void SpawnLime(Vector3 position)
    {
        Instantiate(limePrefab, position, Quaternion.identity);
    }
}
