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
    }

    private void GoBack()
    {
        ActiveButtons(true);
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
