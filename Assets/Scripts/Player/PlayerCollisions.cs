using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{
    public event UnityAction CoinCollision;
    public event UnityAction ObstructionCollision;
    public event UnityAction TriggerRoadEntered;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Obstruction obstruction))
        {
            Explosion();
            ObstructionCollision?.Invoke();
        }
        
        if (col.TryGetComponent(out Coin coin))
        {
            CoinCollision?.Invoke();
        }
        
        if (col.TryGetComponent(out SpawnTriggerRoad spawnTriggerRoad))
        {
            TriggerRoadEntered?.Invoke();
        }
    }

    private void Explosion()
    {
        //gameObject.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        PlayAllParticles();
    }
    
    private void PlayAllParticles()
    {
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        
        foreach (ParticleSystem particle in particles) 
            particle.Play();
    }
}
