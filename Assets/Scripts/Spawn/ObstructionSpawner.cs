using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstructionSpawner : ObjectPool
{
    [SerializeField] private GameObject _obstructionPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    
    private bool _coroutineAllowed = true;

    private void Start()
    {
        Initialize(_obstructionPrefab);
    }
    
    private void Update()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine(DelayAppearance());
        }
    }

    private IEnumerator DelayAppearance()
    {
        _coroutineAllowed = false;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        while (Time.timeScale > 0)
        {
            if (TryGameObject(out GameObject obstruction))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetGameObject(obstruction, _spawnPoints[spawnPointNumber].position);
            }
            
            yield return waitForSeconds;
        }
        _coroutineAllowed = true;
    }
    
    private void SetGameObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
