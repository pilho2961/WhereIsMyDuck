using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class WaterSplash : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(TriggerSplash());
    }

    IEnumerator TriggerSplash()
    {

        yield return new WaitForSeconds(2.1f);

        Destroy(gameObject);
    }




}