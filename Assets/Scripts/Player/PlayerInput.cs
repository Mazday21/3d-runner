using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private Vector3 _startTouchPosition;
    private Vector3 _endTouchPosition;

    
    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            _startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            if (_endTouchPosition.x != _startTouchPosition.x)
                _mover.TrySwipeSide(_endTouchPosition.x - _startTouchPosition.x);
            else if (Input.touchCount > 0)
                _mover.TryJump();
        }
    }
}
