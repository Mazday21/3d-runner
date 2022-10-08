using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{
    public event UnityAction CoinCollided;
    public event UnityAction ObstructionCollided;
    public event UnityAction TriggerRoadEntered;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Obstruction obstruction))
        {
            Explosion();
            ObstructionCollided?.Invoke();
        }
        
        if (col.TryGetComponent(out Coin coin))
        {
            CoinCollided?.Invoke();
        }
        
        if (col.TryGetComponent(out SpawnTriggerRoad spawnTriggerRoad))
        {
            TriggerRoadEntered?.Invoke();
        }
    }

    private void Explosion()
    {
        PlayAllParticles();
    }
    
    private void PlayAllParticles()
    {
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        
        foreach (ParticleSystem particle in particles) 
            particle.Play();
    }
}
