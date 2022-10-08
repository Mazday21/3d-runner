
using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private PlayerCollisions _playerCollisions;

    public event UnityAction Death;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void OnEnable()
    {
        _playerCollisions.ObstructionCollided += HealthChange;
    }

    private void OnDisable()
    {
        _playerCollisions.ObstructionCollided -= HealthChange;
    }
    
    private void HealthChange()
    {
        _health -= 1;
        HealthChanged?.Invoke(_health);
        if(_health <= 0)
            Dying();
    }

    private void Dying()
    {
        Death?.Invoke();
    }
}
