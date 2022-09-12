using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForvard : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
    
    private void Update()
    {
        transform.Translate(new Vector3(0, 0 , _speed) * Time.deltaTime);
    }
}
