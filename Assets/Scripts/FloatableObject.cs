using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    Rigidbody rb;

    Coroutine dirCor;
    Coroutine fixCor;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Start()
    {
        waterSurface = GameObject.Find("Water").GetComponent<Transform>();

        posOffset = transform.position;
        posOffset.y = waterSurface.position.y;

        dirCor = StartCoroutine(SetMoveDirection());
        fixCor = StartCoroutine(FixDistortion());
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

        posOffset.x += moveDir.x * moveSpeed * Time.deltaTime;
        posOffset.z += moveDir.z * moveSpeed * Time.deltaTime;

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

    protected IEnumerator FixDistortion()
    {
        while (gameObject.activeSelf)
        {
            if (rb.transform.localPosition != Vector3.zero)
            {
                Vector3 tempPos = rb.transform.position;
                rb.transform.localPosition = Vector3.zero;
                transform.position = tempPos;

                posOffset = transform.position;
                posOffset.y = waterSurface.position.y;
            }
            
            yield return new WaitForSeconds(2);
        }
    }

    private void OnDestroy()
    {
        if (fixCor != null)
        {
            StopCoroutine(dirCor);
            StopCoroutine(fixCor);
        }
    }
}
