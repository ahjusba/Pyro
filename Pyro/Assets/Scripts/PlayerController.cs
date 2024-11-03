using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 10;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _rb = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //MOVE
        var direction = _playerInput.MoveDirection;
        var newPosition = _rb.position + direction * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);

        //ROTATE
        var lookDirection = _playerInput.LookDirection;
        if(lookDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
    }
}
