using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : SingletonBehaviour<UIManager>
{
    [Header("Main Menu Buttons")]
    [SerializeField]
    Button openStoryBookButton;
    [SerializeField]
    Button openMapButton;

    [SerializeField]
    Button quitButton;

    [SerializeField]
    Button closeButton;

    [Header("UI")]
    [SerializeField]
    GameObject MapUI;

    void Start()
    {
        openStoryBookButton.onClick.AddListener(OpenStoryBook);
        openMapButton.onClick.AddListener(OpenMap);
        quitButton.onClick.AddListener(QuitGame);
        closeButton.onClick.AddListener(GoBack);
    }

    private void OpenStoryBook()
    {
        ActiveButtons(false);
    }

    private void OpenMap()
    {
        ActiveButtons(false);
        MapUI.SetActive(true);
        StartCoroutine(GPSManager.Instance.StartLocationService());
    }

    private void GoBack()
    {
        ActiveButtons(true);
        MapUI.SetActive(false);
        StopCoroutine(GPSManager.Instance.StartLocationService());
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ActiveButtons(bool isActive)
    {
        openStoryBookButton.gameObject.SetActive(isActive);
        openMapButton.gameObject.SetActive(isActive);
        quitButton.gameObject.SetActive(isActive);

        closeButton.gameObject.SetActive(!isActive);
    }
}
