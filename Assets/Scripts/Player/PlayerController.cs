using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _swipeDuration = 0.1f;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMoveForvard _playerMoveForvard;
    
    private float _leftLine = -3;
    private float _rightLine = 3;
    private Vector3 _startTouchPosition;
    private Vector3 _endTouchPosition;
    private float _timer;
    private bool _coroutineAllowed = true;
    private float _startYPosition = 0.5f;
    private readonly int _hashAnimGrounded = Animator.StringToHash("Grounded");

    private void Start()
    {
        _animator.SetBool(_hashAnimGrounded, true);
    }
    
    private void Update()
    {
        SwipeMove();
    }

    private void SwipeMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            _startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            if ((_endTouchPosition.x < _startTouchPosition.x) && transform.position.x > _leftLine  && _coroutineAllowed)
                StartCoroutine(SwipeSide(_leftLine));
            else if ((_endTouchPosition.x > _startTouchPosition.x) && transform.position.x < _rightLine  && _coroutineAllowed)
                StartCoroutine(SwipeSide(_rightLine));
            else if(Input.touchCount > 0 && _coroutineAllowed)
                StartCoroutine(Jump());
        }
    }

    private IEnumerator SwipeSide(float offsetX)
    {
        _coroutineAllowed = false;
        
        _timer = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x + offsetX, transform.position.y, transform.position.z + _playerMoveForvard.Speed * _swipeDuration);

        while (_timer < _swipeDuration)
        {
            _timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, _timer / _swipeDuration);
            yield return null;
        }
        _coroutineAllowed = true;
    }

    private IEnumerator Jump()
    {
        _coroutineAllowed = false;
        _animator.SetBool(_hashAnimGrounded, false);
        _timer = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, transform.position.y + _jumpHeight, transform.position.z + _playerMoveForvard.Speed * _jumpDuration);

        while (_timer < _jumpDuration )
        {
            _timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, _timer / _jumpDuration);
            
            if (transform.position.y >= _jumpHeight)
            {
                _timer = 0;
                startPosition = transform.position;
                endPosition = new Vector3(startPosition.x, _startYPosition, transform.position.z + _playerMoveForvard.Speed * _jumpDuration);
            }
            yield return null;
        }
        _animator.SetBool(_hashAnimGrounded, true);
        _coroutineAllowed = true;
    }
}
