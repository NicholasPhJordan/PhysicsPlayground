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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rearLeft.targetVelocity = -30000;
            rearRight.targetVelocity = 30000;
        }
        else
        {
            rearLeft.targetVelocity = 0;
        }
    }
}
