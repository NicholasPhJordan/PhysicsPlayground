using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerBehaviour _script;
    [SerializeField] private GameObject _player;
    [SerializeField] private HealthBehaviour healthBar;
    [SerializeField] public float maxHealth;

    private float health;
    private Vector3 _homePos;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (_player.transform.position.y <= 20.0f)
        {
            _animator.enabled = false;
        }

        if (health <= 0.0f)
        {
            _animator.enabled = false;
            _script.enabled = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Killer"))
        {
            Destroy(hit.gameObject);
            health -= 10.0f;
            healthBar.SetHealth(health);
        }
        else if (hit.gameObject.CompareTag("Platform"))
        {
            _homePos = _player.transform.position;
            _homePos.y += 1;
        }
        else if (hit.gameObject.CompareTag("Void"))
        {
            health -= 20.0f;
            healthBar.SetHealth(health);
            _player.transform.position = _homePos;
            _animator.enabled = true;
        }
    }
}
