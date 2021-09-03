using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    public HingeJoint backLeft;
    public HingeJoint backRight;

    private JointMotor rearLeft;
    private JointMotor rearRight;

    private void Start()
    {
        rearLeft = backLeft.motor;
        rearRight = backRight.motor;

        rearLeft.targetVelocity = 0.0f;
        rearRight.targetVelocity = 0.0f;
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rearLeft.targetVelocity = -10000.0f;
            rearRight.targetVelocity = 10000.0f;
        }
    }
}
