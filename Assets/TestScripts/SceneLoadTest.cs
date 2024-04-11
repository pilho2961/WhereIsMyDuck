using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneLoader.Instance.LoadGameScene();
        }
    }
}
