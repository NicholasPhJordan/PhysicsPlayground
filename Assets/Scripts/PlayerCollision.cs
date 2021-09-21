using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _player;

    private bool _playerScript;
    private Vector3 _homePos;

    private void Start()
    {
        _playerScript = _player.GetComponent<PlayerBehaviour>().enabled;
    }

    private void Update()
    {
        if (_player.transform.position.y <= 20.0f)
        {
            _animator.enabled = false;
            _playerScript = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Killer"))
        {
            _animator.enabled = false;
            _playerScript = false;
        }
        else if (hit.gameObject.CompareTag("Platform"))
        {
            _homePos = _player.transform.position;
            _homePos.y += 1;
        }
        else if (hit.gameObject.CompareTag("Void"))
        {
            _player.transform.position = _homePos;
            _animator.enabled = true;
        }
    }
}
