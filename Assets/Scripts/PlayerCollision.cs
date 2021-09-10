using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject player;

    private bool playerScript;
    private Vector3 homePos;

    private void Start()
    {
        homePos = player.transform.position;

        playerScript = player.GetComponent<PlayerBehaviour>().enabled;
    }

    private void Update()
    {
        if (player.transform.position.y <= 20.0f)
        {
            _animator.enabled = false;
            playerScript = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Killer"))
        {
            _animator.enabled = false;
            playerScript = false;
        }
        else if (hit.gameObject.CompareTag("Void"))
        {
            player.transform.position = homePos;
            _animator.enabled = true;
        }
    }
}
