using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private int _minInactiveCapacity;

    private List<GameObject> _pool = new List<GameObject>();
    private GameObject _prefab;
    private bool _coroutineStarted;
    private float _secondsBetweenGarbageCollect;
    
    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _minCapacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform.position, Quaternion.Euler(-90,90,0));
            spawned.SetActive(false);
            _pool.Add(spawned);
        }

        _prefab = prefab;
    }

    protected GameObject IncreaseCapacity()
    {
        GameObject spawned = Instantiate(_prefab, _container.transform.position, Quaternion.Euler(-90,90,0));
        _pool.Add(spawned);
        return spawned;
    }

    protected bool TryGetGameObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        if (result == null && _pool.Capacity < _maxCapacity)
        {
            result = IncreaseCapacity();
            return true;
        }
        
        return result != null;
    }

    private void GarbageCollect(int minInactiveCapacity)
    {
        int counterInactive = 0;
        for (int i = 0; i < _pool.Capacity; i++)
        {
            if (_pool[i].activeSelf == false)
            {
                counterInactive++;
                if (counterInactive > minInactiveCapacity)
                {
                    GameObject garbage = _pool[i];
                    _pool.Remove(_pool[i]);
                    Destroy(garbage);
                }
            }
        }
    }
    
    IEnumerator DelayBetweenGarbageCollect()
    {
        _coroutineStarted = true;
        
        for(;;)
        {
            GarbageCollect(_minInactiveCapacity);
            yield return new WaitForSeconds(_secondsBetweenGarbageCollect);
            _coroutineStarted = false;
        }
    }

    protected void FixedUpdate()
    {
        if (Time.timeScale > 0 && !_coroutineStarted)
        {
            StartCoroutine(DelayBetweenGarbageCollect());
        }
    }
}
