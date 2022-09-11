
using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _score;
    [SerializeField] private PlayerCollisions _playerCollisions;
    [SerializeField] private int _costLive = 20;

    public event UnityAction Death;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreChanged;

    private int _maxHealth = 3;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        ScoreChanged?.Invoke(_score);
    }

    private void OnEnable()
    {
        _playerCollisions.CoinCollision += ScoreChange;
        _playerCollisions.ObstructionCollision += HealthChange;
    }

    private void OnDisable()
    {
        _playerCollisions.CoinCollision -= ScoreChange;
        _playerCollisions.ObstructionCollision -= HealthChange;
    }
    
    private void HealthChange()
    {
        _health -= 1;
        HealthChanged?.Invoke(_health);
        if(_health <= 0)
            Dying();
    }

    private void ScoreChange()
    {
        _score += 1;
        if (_score >= _costLive && _health < _maxHealth)
        {
            _score -= _costLive;
            _health++;
            HealthChanged?.Invoke(_health);
        }
        ScoreChanged?.Invoke(_score);
    }

    private void Dying()
    {
        Death?.Invoke();
    }
}
