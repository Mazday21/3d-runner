using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField]private AudioSource _coinJingle;
    [SerializeField]private AudioSource _gong;
    [SerializeField] private PlayerCollisions _playerCollisions;
    private void OnEnable()
    {
        _playerCollisions.CoinCollision += RingingCoin;
        _playerCollisions.ObstructionCollision += Exploded;
    }

    private void OnDisable()
    {
        _playerCollisions.CoinCollision -= RingingCoin;
        _playerCollisions.ObstructionCollision -= Exploded;
    }

    private void RingingCoin()
    {
        _coinJingle.Play();
    }

    private void Exploded()
    {
        _gong.Play();
    }
}
