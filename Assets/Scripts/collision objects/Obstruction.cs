using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Destroyer destroyer) || col.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
        }
    }
}
