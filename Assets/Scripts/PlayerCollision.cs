using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Die!!");
        _animator.enabled = false;
    }
}
