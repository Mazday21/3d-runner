using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverForvard : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
