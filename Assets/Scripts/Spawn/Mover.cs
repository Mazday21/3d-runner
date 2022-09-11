using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    
    private void Update()
    {
        transform.Translate(new Vector3(0, 0 , _player.Speed) * Time.deltaTime);
    }
}
