using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool _isCreditsActive;
    private bool _isOptionsActive;

    [Header("Play Game")]
    [SerializeField] Button _playButton;
    [SerializeField] string _tutorialScene;

    [Header("Buttons")]
    [SerializeField] Button _creditsButton;
    [SerializeField] Button _exitButton;
    [SerializeField] Button _creditsBackButton;

    [Header("Panels")]
    [SerializeField] GameObject _initialPanel;
    [SerializeField] GameObject _creditsPanel;

    public void ToPlay()
    {
        //_bgMusic.StopMusic();
        SceneManager.LoadScene(_tutorialScene);
    }

    // Goes Back To The Initial Panel
    public void ToGoBack()
    {
        _initialPanel.SetActive(true);
        if (_isCreditsActive)
        {
            _creditsPanel.SetActive(false);
            _isCreditsActive = false;
        }
    }

    // Toggles The Credits Panel
    public void ToCredits()
    {
        _isCreditsActive = true;
        _initialPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }

    public void ToExit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}