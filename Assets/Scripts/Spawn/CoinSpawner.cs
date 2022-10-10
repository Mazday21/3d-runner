using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectPool
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    
    private float _YOffset = 1.5f;
    private Transform[] _coinSpawnPoints;
    private bool _coroutineAllowed = true;
    
    private void Start()
    {
        Initialize(_coinPrefab.gameObject);
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
        bool firstSpawned = false;

        while (Time.timeScale > 0)
        {
            if (!firstSpawned)
            {
                yield return new WaitForSeconds(0.5f);
                firstSpawned = true;
            }
            else
            {
                yield return waitForSeconds;
            }

            GetOrInstantiateGameObject(out GameObject coin);
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            SetGameObject(coin, _spawnPoints[spawnPointNumber].position);
        }
        _coroutineAllowed = true;
    }
    
    private void SetGameObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(spawnPoint.x, spawnPoint.y + _YOffset, spawnPoint.z);
        gameObject.transform.rotation = Quaternion.Euler(0, 90,0);
    }
}
