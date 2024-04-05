using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Quaternion initRot;
    public float rotateSpeed = 50;

    private void Awake()
    {
        initRot = transform.rotation;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateSpeed;

        transform.Rotate(0, -x, 0, Space.World);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �ٽ� �� ó�� ���·� �ǵ�����
        float x = (transform.rotation.y - initRot.y) * Time.deltaTime * rotateSpeed;

        transform.Rotate(0, x, 0, Space.World);
    }
}
