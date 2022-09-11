using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectPool
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0.5f;
    private float _YOffset = 1.5f;
    private Transform[] _coinSpawnPoints;
    
    private void Start()
    {
        Initialize(_coinPrefab);
    }
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGameObject(out GameObject coin))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetGameObject(coin, _spawnPoints[spawnPointNumber].position);
            }
        }
    }
    
    private void SetGameObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(spawnPoint.x, spawnPoint.y + _YOffset, spawnPoint.z);
        gameObject.transform.rotation = Quaternion.Euler(0, 90,0);
    }
}
