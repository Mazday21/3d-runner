using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreAmount;
    [SerializeField] private Image[] _hearts;

    private void OnEnable()
    {
        _player.ScoreChanged += ScoreDraw;
        _player.HealthChanged += HeartDraw;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= ScoreDraw;
        _player.HealthChanged += HeartDraw;
    }
    
    private void HeartDraw(int health)
    {
        if (health == 3)
        {
            _hearts[2].enabled = true;
        }
        if (health == 2)
        {
            _hearts[2].enabled = false;
            _hearts[1].enabled = true;
        }
        else if (health == 1)
        {
            _hearts[1].enabled = false;
        }
        else if(health == 0)
            _hearts[0].enabled = false;
    }
    
    private void ScoreDraw(int score)
    {
        _scoreAmount.text = score.ToString();
    }
}
