using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TouchController _touchController;
    [SerializeField] private GameObject _observatoryPanel;

    [SerializeField] private Button _loadObservatorySceneButton;

    [SerializeField] private Button _closeObservatoryPanelButton;

    private void Awake()
    {
        _loadObservatorySceneButton.onClick.AddListener(LoadScene);
        _closeObservatoryPanelButton.onClick.AddListener(() => ObservatoryPanelVisible(false));
        _touchController.OnObservatoryClick += OnObservatoryClick;
    }

    private void OnObservatoryClick()
    {
        if (!_observatoryPanel.activeSelf)
        {
            ObservatoryPanelVisible(true);
        }
    }

    private void ObservatoryPanelVisible(bool value)
    {
        _observatoryPanel.SetActive(value);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("ObservatoryARScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        ObservatoryPanelVisible(false);
    }
    
}
