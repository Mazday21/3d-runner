using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private PlayerCollisions _playerCollisions;
    
    private int _score;
    
    public event UnityAction<int> ScoreChanged;
    
    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }
    
    private void OnEnable()
    {
        _playerCollisions.CoinCollided += ScoreChange;
    }

    private void OnDisable()
    {
        _playerCollisions.CoinCollided -= ScoreChange;
    }
    
    private void ScoreChange()
    {
        _score += 1;
        ScoreChanged?.Invoke(_score);
    }
}
