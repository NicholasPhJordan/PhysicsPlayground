using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    void Update()
    {
        if (_target)
        {
            transform.LookAt(_target.transform);
        }
    }
}
