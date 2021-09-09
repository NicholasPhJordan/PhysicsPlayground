using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Killer"))
        {
            _animator.enabled = false;
            Debug.Log("you died bitch");
        }
    }
}
