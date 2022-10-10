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

    private Queue<GameObject> _queue = new Queue<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        //for (int i = 0; i < _minCapacity; i++)
        //{
        //    GameObject spawned = Instantiate(prefab, _container.transform.position, Quaternion.Euler(-90,90,0));
        //    spawned.SetActive(false);
        //    _pool.Add(spawned);
        //}
        GameObject spawned = Instantiate(prefab, _container.transform.position, Quaternion.Euler(-90, 90, 0));
        _queue.Enqueue(spawned);

        _prefab = prefab;
    }

    private GameObject IncreaseCapacity()
    {
        GameObject spawned = Instantiate(_prefab, _container.transform.position, Quaternion.Euler(-90,90,0));
        _queue.Enqueue(spawned);
        return spawned;
    }

    protected void GetOrInstantiateGameObject(out GameObject result)
    {
        //result = _pool.FirstOrDefault(p => p.activeSelf == false);

        //if (result == null && _pool.Capacity < _maxCapacity)
        //{
        //    result = IncreaseCapacity();
        //    return true;
        //}
        
        //return result != null;

        
        if (!_queue.TryDequeue(out result))
        {
            result = IncreaseCapacity();
        }
    }

    public void ReturnGameObject(GameObject gameObject)
    {
        _queue.Enqueue(gameObject);
    }
}
