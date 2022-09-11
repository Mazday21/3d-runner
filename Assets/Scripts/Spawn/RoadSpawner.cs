
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private PlayerCollisions _playerCollisions;
    
    private float _roadLenght = 89.6f;

    private void OnEnable()
    {
        _playerCollisions.TriggerRoadEntered += LayRoad;
    }

    private void OnDisable()
    {
        _playerCollisions.TriggerRoadEntered -= LayRoad;
    }

    private void Start()
    {
        _roads = _roads.OrderBy(r => r.transform.position.z).ToList();
    }

    private void LayRoad()
    {
        GameObject movedRoad = _roads[0];
        _roads.Remove(movedRoad);
        float newPositionZ = _roads[_roads.Count - 1].transform.position.z + _roadLenght;
        movedRoad.transform.position = new Vector3(0, 0, newPositionZ);
        _roads.Add(movedRoad);
    }
}
