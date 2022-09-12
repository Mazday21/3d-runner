using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private PlayerMoveForvard _playerMoveForvard;
    
    private void Update()
    {
        transform.Translate(new Vector3(0, 0 , _playerMoveForvard.Speed) * Time.deltaTime);
    }
}
