using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceFromTarget = 0.0f;
    [SerializeField] private float sensitivity = 0.0f;
    [SerializeField] private bool invertY = false;

    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            //Store current angles
            Vector3 angles = transform.eulerAngles;

            //Get input
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");

            //Look up and down by rotating around the X-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity, 0.0f, 70.0f);

            //Look left and right by rotating around the Y-axis
            angles.y += rotation.y * sensitivity;

            //Set the angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        transform.position = _target.position + (_distanceFromTarget * -transform.forward);
    }
}
