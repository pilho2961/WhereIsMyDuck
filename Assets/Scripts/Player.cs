using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float interactionDistance = 10f; // Maximum distance for raycasting
    public LayerMask duckLayer; // LayerMask for the Duck objects

    private DuckCounter duckCounter;

    private void Start()
    {
        duckCounter = GameObject.Find("DuckCounter").GetComponent<DuckCounter>();
    }

    void Update()
    {
        CollectDuck();
    }

    private void CollectDuck()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red, 1f);
            // Perform raycast and check for hits
            if (Physics.Raycast(ray, out hit, interactionDistance, duckLayer))
            {
                // Check if the hit object has the "Duck" tag
                if (hit.collider.CompareTag("Duck"))
                {
                    duckCounter.CountCollectedDucks(hit.collider.gameObject.GetComponent<Duck>().duckId);
                    // Call a function to handle interaction with the Duck object
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
