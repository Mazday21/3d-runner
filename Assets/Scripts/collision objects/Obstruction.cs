using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstruction : MonoBehaviour
{
    [SerializeField] private ObstructionSpawner obstructionSpawner;
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Destroyer destroyer) || col.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
            obstructionSpawner.ReturnGameObject(gameObject);
        }
    }
}
