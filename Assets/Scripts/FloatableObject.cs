using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatableObject : MonoBehaviour
{
    protected float RotationSpeed;
    public float Bounciness = 0.1f;
    public float Frequency = 1f;
    public float moveSpeed = 0.2f;
    public float minSec = 3f;
    public float maxSec = 12f;

    Transform waterSurface;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    Vector3 moveDir = new Vector3();

    void Start()
    {
        waterSurface = GameObject.Find("Water").GetComponent<Transform>();

        posOffset = transform.position;
        posOffset.y = waterSurface.position.y;

        StartCoroutine(SetMoveDirection());
    }


    void Update()
    {
        Float();
    }
	protected void Float()
	{
        transform.Rotate(new Vector3(0f, Time.deltaTime * RotationSpeed, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Bounciness;

        tempPos.x += moveDir.x * moveSpeed * Time.deltaTime;
        tempPos.z += moveDir.z * moveSpeed * Time.deltaTime;

        transform.position = tempPos;
    }

    protected IEnumerator SetMoveDirection()
	{
        while (gameObject.activeSelf)
		{
			moveDir = (transform.position + Random.insideUnitSphere) - transform.position;
			moveDir.y = 0;
			moveDir = moveDir.normalized;

			float randSec = Random.Range(minSec, maxSec);

            yield return new WaitForSeconds(randSec);
		}
	}
}
