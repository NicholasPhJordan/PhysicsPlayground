using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Die!!");
            _animator.enabled = false;

        }
    }
}
