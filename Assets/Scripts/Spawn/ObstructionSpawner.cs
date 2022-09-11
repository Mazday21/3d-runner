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

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_obstructionPrefab);
    }
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGameObject(out GameObject obstruction))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetGameObject(obstruction, _spawnPoints[spawnPointNumber].position);
            }
        }
    }
    
    private void SetGameObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
