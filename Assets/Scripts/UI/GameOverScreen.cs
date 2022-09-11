using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _gameOverGroup;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    private void Start()
    {
        _gameOverGroup.alpha = 0;
        _restartButton.enabled = false;
        _exitButton.enabled = false;
    }

    private void OnEnable()
    {
        _player.Death += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }
    
    private void OnDisable()
    {
        _player.Death -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
    
    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _restartButton.enabled = true;
        _exitButton.enabled = true;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
