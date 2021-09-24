using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private HealthBehaviour healthBar;
    [SerializeField] public float maxHealth;

    private float health;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (health <= 0.0f)
        {
            Invoke("LoadNextScene", 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 5.0f;
            healthBar.SetHealth(health);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
