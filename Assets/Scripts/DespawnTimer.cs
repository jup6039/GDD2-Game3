using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    // Fields
    private float timer = 0;
    public float despawnTime = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= despawnTime)
            Destroy(gameObject);
    }
}
