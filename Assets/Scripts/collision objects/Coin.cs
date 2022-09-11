using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 200;
    
    
    private void Update()
    {
        Spin();
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Destroyer destroyer) || col.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
        }
    }

    private void Spin()
    {
        transform.Rotate(0,_spinSpeed * Time.deltaTime,0,Space.World);
    }
}
