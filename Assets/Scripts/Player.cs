using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas myCollectionUI;

    public float interactionDistance = 10f; // Maximum distance for raycasting
    public LayerMask duckLayer; // LayerMask for the Duck objects
    public LayerMask waterLayer;

    private DuckCounter duckCounter;

    [SerializeField] private GameObject waterSplash;
    private bool hitObject = false;

    private void Start()
    {
        duckCounter = GameObject.Find("DuckCounter").GetComponent<DuckCounter>();
    }

    void Update()
    {
        // if문 안 조건에 옵션패널도 추가
        if (!UIManager.Instance.playerInfoPanel.activeSelf)
        {
            Click();
        }

        PressTab();
        PressESC();
    }

    private void Click()
    {
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
                    hit.collider.enabled = false;
                    hitObject = true;
                    duckCounter.CountCollectedDucks(hit.collider.gameObject.GetComponent<Duck>().duckId);

                    AudioSource duckSound = hit.collider.gameObject.GetComponent<AudioSource>();

                    // Call a function to handle interaction with the Duck object
                    Destroy(hit.collider.gameObject, duckSound.clip.length - 0.6f);
                    if (!duckSound.isPlaying) duckSound.Play();
                }
            }
            else if (!hitObject)
            {
                if (Physics.Raycast(ray, out hit, interactionDistance, waterLayer))
                {
                    GameObject splash = Instantiate(waterSplash);
                    splash.transform.position = hit.point;
                }
            }

            hitObject = false;
        }
    }

    private void PressTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIManager.Instance.playerInfoPanel.activeSelf)
            {
                UIManager.Instance.CloseInfoPanel();
            }
            else
            {
                UIManager.Instance.OpenInfoPanel();
            }
        }
    }

    private void PressESC()
    {
        // 옵션창 띄우기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if ()
            //{
                
            //}
            //else
            //{
                
            //}
        }
    }
}
