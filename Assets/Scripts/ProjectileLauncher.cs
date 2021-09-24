using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Tooltip("Check if script is on the Player")]
    [SerializeField] private bool _onPlayer;
    [Space]
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float airTime = 2.0f;
    [Tooltip("The time in-between Shots for Non-Player Objects")]
    [SerializeField] private float _instantiationTimer = 2.0f;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private float _time = 0.0f;
    private Vector3 _initialVelocity = new Vector3();
    private Vector3 _finalVelocity = new Vector3();
    private float _ogTimerTime;

    private void Start()
    {
        _ogTimerTime = _instantiationTimer;
    }

    private void Update()
    {
        if (_onPlayer)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.transform;
            }
        }

        if (Input.GetMouseButtonDown(0) && _onPlayer)
        {
            LaunchProjectile();
        }
        else if (!_onPlayer)
        {
            ShootPlayer();
        }
    }

    public void LaunchProjectile()
    {
        _displacement = target.position - transform.position;
        _acceleration = Physics.gravity;
        _time = airTime;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, _time);

        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, _time);

        Rigidbody projectileInstance =  Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.velocity = _initialVelocity;
    }

    //Same as LaunchProjectile, but with a timer on shooting
    public void ShootPlayer()
    {
        _instantiationTimer -= Time.deltaTime;

        _displacement = target.position - transform.position;
        _acceleration = Physics.gravity;
        _time = airTime;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, _time);
        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, _time);

        if (_instantiationTimer <= 0)
        {
            Rigidbody projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.velocity = _initialVelocity;

            _instantiationTimer = _ogTimerTime;
        }
    }

    // FIND FUNCTIONS 

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        // v = v0 + at
        Vector3 finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        // deltaX = v0*t + (1/2)*a*t^2
        Vector3 displacement = initialVelocity * time + 0.5f * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        // deltaX = v0*t + (1/2)*a*t^2
        // deltaX - (1/2)*a*t^2 = v0*t
        // deltaX/t - (1/2)*a*t = v0
        // v0 = deltaX - (1/2)*a*t
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
