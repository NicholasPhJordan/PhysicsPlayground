using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CannonBall : MonoBehaviour
{
    public float fireForce = 0.0f;

    private bool _fire = false;
    private bool _canFire = true;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Start() 
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && _canFire)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.forward * fireForce);
            _canFire = false;
        }
    }
}
