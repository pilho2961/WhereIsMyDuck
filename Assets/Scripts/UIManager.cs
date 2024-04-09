using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    public GameObject playerInfoPanel;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        playerInfoPanel.SetActive(false);
    }

    public void OpenInfoPanel()
    {
        playerInfoPanel.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        playerInfoPanel.SetActive(false);
    }
}
