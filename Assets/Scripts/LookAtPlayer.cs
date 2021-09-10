using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : ProjectileLauncher
{
    [SerializeField] private GameObject _lookAtTarget;
    [SerializeField] private float _waitTime;

    void Update()
    {
        if (_lookAtTarget)
        {
            transform.LookAt(_lookAtTarget.transform);
        }
    }

    IEnumerator ShootPlayer(float time)
    {
        yield return new WaitForSeconds(time);

        LaunchProjectile();
    }
}
