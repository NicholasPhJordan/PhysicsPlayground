using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float gravityModifier;

    private CharacterController _controller;

    private Vector3 _desiredVelcoity;
    private Vector3 _airvelocity;
    private bool _jumpIsDesired;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Get movement input
        _desiredVelcoity.x = Input.GetAxis("Horizontal");
        _desiredVelcoity.y = 0.0f;
        _desiredVelcoity.z = Input.GetAxis("Vertical");

        //Get jump input
        _jumpIsDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude (and speed)
        _desiredVelcoity.Normalize();
        _desiredVelcoity *= speed;

        //Apply jump strength 
        if (_jumpIsDesired)
        {
            _airvelocity.y = jumpStrength;
            _jumpIsDesired = false;
        }

        //Apply Gravity
        _airvelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        _desiredVelcoity += _airvelocity;

        //Apply Move
        _controller.Move((_desiredVelcoity + _airvelocity) * Time.deltaTime);
    }
}
