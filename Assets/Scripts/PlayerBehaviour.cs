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

    [SerializeField] private Animator _animator;

    private CharacterController _controller;

    private Vector3 _desiredVelcoity;
    private Vector3 _airvelocity;
    private bool _jumpIsDesired = false;
    private bool _isGrounded = false;

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

        //Get Camera forward
        Vector3 cameraForward = _playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = _playerCamera.transform.right;

        //Find the desired velocity 
        _desiredVelcoity = _desiredVelcoity.x * cameraRight + _desiredVelcoity.z * cameraForward;

        //Get jump input
        _jumpIsDesired = Input.GetButton("Jump");

        //Set movement magnitude (and speed)
        _desiredVelcoity.Normalize();
        _desiredVelcoity *= _speed;

        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Update animations
        if (faceWithCamera)
        {

            transform.forward = cameraForward;
            _animator.SetFloat("Speed", _desiredVelcoity.y);
            _animator.SetFloat("Direction", _desiredVelcoity.x);
        }
        else
        {
            if (_desiredVelcoity != Vector3.zero)
                transform.forward = _desiredVelcoity.normalized;
            _animator.SetFloat("Speed", _desiredVelcoity.magnitude / _speed);
        }
        _animator.SetBool("Jump", !_isGrounded);

        //Apply jump strength 
        if (_jumpIsDesired && _isGrounded)
        {
            _airvelocity.y = _jumpStrength;
            _jumpIsDesired = false;
        }

        //Stop on ground
        if (_isGrounded && _airvelocity.y < 0.0f)
            _airvelocity.y = -1.0f;

        //Apply Gravity
        _airvelocity += Physics.gravity * _gravityModifier * Time.deltaTime;

        //Add air velocity
        _desiredVelcoity += _airvelocity;

        //Move
        _controller.Move((_desiredVelcoity + _airvelocity) * Time.deltaTime);
    }
}
