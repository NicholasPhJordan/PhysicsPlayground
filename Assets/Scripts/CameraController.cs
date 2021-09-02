using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistance = 0.0f;
    [SerializeField] private float _sensitivity = 0.0f;
    [SerializeField] private bool _invertY = false;
    [SerializeField] private float returnSpeed = 0.0f;

    private float _currentDistance;

    private void Start()
    {
        _currentDistance = _maxDistance;
    }

    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            //Store current angles
            Vector3 angles = transform.eulerAngles;

            //Get input
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (_invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");

            //Look up and down by rotating around the X-axis
            angles.x += rotation.x * _sensitivity;
            angles.x = Mathf.Clamp(angles.x, 0.0f, 70.0f);

            //Look left and right by rotating around the Y-axis
            angles.y += rotation.y * _sensitivity;

            //Set the angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        RaycastHit hitInfo;
        if (Physics.Raycast(_target.position, -transform.forward, out hitInfo, _maxDistance))
        {
            _currentDistance = hitInfo.distance;
        }
        else
        {
            _currentDistance = Mathf.MoveTowards(_currentDistance, _maxDistance, returnSpeed * Time.deltaTime);
        }

        transform.position = _target.position + (_currentDistance * -transform.forward);
    }
}
