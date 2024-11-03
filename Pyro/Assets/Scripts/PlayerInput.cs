using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveDirection;
    public Vector2 LookDirection;
    [SerializeField] private float _triggerThreshold = 0.7f;
    private bool _leftTriggerPressedLastFrame = false;
    private bool _rightTriggerPressedLastFrame = false;


    void Update()
    {
        //MOVE
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        MoveDirection = new Vector3(moveHorizontal, 0f, moveVertical);

        //ROTATE
        float rotateHorizontal = Input.GetAxis("RightStickHorizontal");
        float rotateVertical = Input.GetAxis("RightStickVertical");
        LookDirection = new Vector2(rotateHorizontal, -rotateVertical);

        //SHOOT
        float leftTrigger = Input.GetAxis("LeftTrigger");
        if (leftTrigger > _triggerThreshold && !_leftTriggerPressedLastFrame)
        {
            _leftTriggerPressedLastFrame = true;
            Debug.Log("LeftTrigger");
        }

        //DASH
        float rightTrigger = Input.GetAxis("RightTrigger");
        if (rightTrigger > _triggerThreshold && !_rightTriggerPressedLastFrame)
        {
            _rightTriggerPressedLastFrame = true;
            Debug.Log("RightTrigger");
        }

        if(leftTrigger == 0)
        {
            _leftTriggerPressedLastFrame = false;
        }

        if(rightTrigger == 0)
        {
            _rightTriggerPressedLastFrame = false;
        }

        
    }
}
