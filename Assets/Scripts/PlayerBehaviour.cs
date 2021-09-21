using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _airControl = 1.0f; 
    [SerializeField] private float _gravityModifier;
    [SerializeField] private bool faceWithCamera = true;

    [SerializeField] private Camera _playerCamera;

    private CharacterController _controller;
    [SerializeField] private Animator _animator;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _jumpIsDesired = false;
    private bool _isGrounded = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Get movement input
        float inputForward = Input.GetAxis("Vertical"); 
        float inputRight = Input.GetAxis("Horizontal"); 

        //Get Camera forward
        Vector3 cameraForward = _playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = _playerCamera.transform.right;

        //Find the desired velocity 
        _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

        //Get jump input
        _jumpIsDesired = Input.GetButton("Jump");

        //Set movement magnitude (and speed)
        _desiredVelocity.Normalize();
        _desiredVelocity *= _speed;

        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Update animations
        if (faceWithCamera)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputForward);
            _animator.SetFloat("Direction", inputRight);
        }
        else
        {
            if (_desiredVelocity != Vector3.zero)
                transform.forward = _desiredVelocity.normalized;
            _animator.SetFloat("Speed", _desiredVelocity.magnitude / _speed);
        }
        _animator.SetBool("Jump", !_isGrounded);
        _animator.SetFloat("VerticalSpeed", _airVelocity.y / _jumpStrength);

        //Apply jump strength 
        if (_jumpIsDesired && _isGrounded)
        {
            _airVelocity.y = _jumpStrength;
            _jumpIsDesired = false;
        }

        //Stop on ground
        if (_isGrounded && _airVelocity.y < 0.0f)
            _airVelocity.y = -1.0f;

        //Apply Gravity
        _airVelocity += Physics.gravity * _gravityModifier * Time.deltaTime;

        //Add air velocity
        _desiredVelocity += _airVelocity;

        //Move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
