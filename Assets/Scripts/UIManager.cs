using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    public GameObject playerInfoPanel;
    public GameObject optionPanel;
    public GameObject playGuidePanel;

    enum PanelState
    {
        OnPlayGuidePanel,
        None,
        OnOptionPanel,
        OnPlayerInfoPanel
    }

    PanelState currentPanelState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentPanelState = PanelState.OnPlayGuidePanel;
        optionPanel.SetActive(false);
        UpdatePanels();
        //playerInfoPanel.SetActive(false);
        //optionPanel.SetActive(false);
        //playGuidePanel.SetActive(true);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (optionPanel.activeSelf)
        //    {
        //        CloseOptionPane();
        //    }
        //    else
        //    {
        //        OpenOptionPanel();
        //    }
        //}

        UpdatePanels();
    }

    private void UpdatePanels()
    {
        switch (currentPanelState)
        {
            case PanelState.OnPlayGuidePanel:
                playGuidePanel.SetActive(true);
                playerInfoPanel.SetActive(false);

                if (!optionPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
                {
                    currentPanelState = PanelState.None;
                }
                else if (optionPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
                {
                    currentPanelState = PanelState.OnOptionPanel;
                }

                break;

            case PanelState.OnPlayerInfoPanel:
                playerInfoPanel.SetActive(true);
                playGuidePanel.SetActive(false);
                optionPanel.SetActive(false);

                if (playerInfoPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
                {
                    currentPanelState = PanelState.None;
                }

                break;

            case PanelState.OnOptionPanel:
                optionPanel.SetActive(true);
                playGuidePanel.SetActive(false);
                playerInfoPanel.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    currentPanelState = PanelState.None;
                }

                break;
            case PanelState.None:
                optionPanel.SetActive(false);
                playGuidePanel.SetActive(false);
                playerInfoPanel.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    currentPanelState = PanelState.OnOptionPanel;
                }
                else if (Input.GetKeyDown(KeyCode.Tab))
                {
                    currentPanelState = PanelState.OnPlayerInfoPanel;
                }

                break;
            default:
                break;
        }
    }

    public void OpenInfoPanel()
    {
        playerInfoPanel.SetActive(true);
        currentPanelState = PanelState.OnPlayerInfoPanel;
    }

    public void CloseInfoPanel()
    {
        playerInfoPanel.SetActive(false);
        currentPanelState = PanelState.None;
    }

    public void OpenOptionPanel()
    {
        optionPanel.SetActive(true);
        currentPanelState = PanelState.OnOptionPanel;
    }

    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
        currentPanelState = PanelState.None;
    }

    public void OpenPlayGuidePanel()
    {
        playGuidePanel.SetActive(true);
        currentPanelState = PanelState.OnPlayGuidePanel;
    }

    public void ClosePlayGuidePanel()
    {
        playGuidePanel.SetActive(false);

        if (optionPanel.activeSelf)
        {
            currentPanelState = PanelState.OnOptionPanel;
        }
        else
        {
            currentPanelState = PanelState.None;
        }
    }

    public void ToTitleScene()
    {
        currentPanelState = PanelState.None;
    }
}
