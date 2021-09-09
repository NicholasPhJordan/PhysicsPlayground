using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject player;

    private bool playerScript;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerBehaviour>().enabled;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Killer"))
        {
            _animator.enabled = false;
            playerScript = false;
        }
    }
}
