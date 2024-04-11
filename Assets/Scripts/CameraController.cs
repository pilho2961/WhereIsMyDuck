using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform poolCenter; // Reference to the pool's center
    private float rotationSpeed = 40f; // Speed of camera rotation
    private float zoomSpeed = 5f; // Speed of camera zoom
    private float maxZoom = 11.4f; // Maximum zoom distance
    private float minZoom = 5f; // Minimum zoom distance
    private float angle = 0f;
    private float targetZoomDistance = 10f;

    void Update()
    {
        if (!UIManager.Instance.playerInfoPanel.activeSelf &&
            !UIManager.Instance.optionPanel.activeSelf &&
            !UIManager.Instance.playGuidePanel.activeSelf)
        {
            CameraMove();
        }
    }

    private void CameraMove()
    {
        // Input for rotation (clockwise and counterclockwise)
        float rotateInput = Input.GetAxis("Horizontal");

        // Calculate the new angle based on input and rotation speed
        angle += rotateInput * rotationSpeed * Time.deltaTime;

        // Input for zooming (scroll wheel)
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the new target zoom distance based on input
        targetZoomDistance -= zoomInput * zoomSpeed;
        targetZoomDistance = Mathf.Clamp(targetZoomDistance, minZoom, maxZoom);

        // Calculate the current zoom distance using Lerp for smooth movement
        float currentZoomDistance = Mathf.Lerp(transform.position.y, targetZoomDistance, zoomSpeed);

        // Calculate the target position on the circle using polar coordinates
        float targetX = poolCenter.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * currentZoomDistance;
        float targetZ = poolCenter.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * currentZoomDistance;

        // Update the camera's position to orbit around the pool center with smooth zooming
        Vector3 newPosition = new Vector3(targetX, transform.position.y, targetZ);
        transform.position = newPosition;

        // Make the camera look at the pool center
        transform.LookAt(poolCenter.position + Vector3.up * 2f);
    }
}
