using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Quaternion initRot;
    public float rotateSpeed = 50;
    public float rotationDuration = 1f; // Adjust as needed for the speed of rotation
    private Coroutine rotateCoroutine;

    private void Awake()
    {
        initRot = transform.rotation;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateSpeed;

        transform.Rotate(0, -x, 0, Space.World);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Start the coroutine to rotate back to initial state
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
        rotateCoroutine = StartCoroutine(RotateBackToInitial());
    }

    private IEnumerator RotateBackToInitial()
    {
        float elapsedTime = 0f;
        Quaternion currentRotation = transform.rotation;

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(currentRotation, initRot, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final rotation is exactly initial rotation
        transform.rotation = initRot;
        rotateCoroutine = null;
    }


}
