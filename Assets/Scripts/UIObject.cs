using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 pointerOffset;

    public void OnDrag(PointerEventData eventData)
    {
        transform.Rotate(Input.mousePosition.y * Time.deltaTime, Input.mousePosition.x * Time.deltaTime, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.Rotate(Vector3.zero);
    }
}
