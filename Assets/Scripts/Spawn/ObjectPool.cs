using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private GameObject _prefab;

    private Queue<GameObject> _queue = new Queue<GameObject>();

    protected void Initialize(GameObject prefab)
    {
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
