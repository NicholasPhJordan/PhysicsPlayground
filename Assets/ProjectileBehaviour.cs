using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float destroyHieght = 20.0f;

    private void Update()
    {
        if (projectile.transform.position.y <= destroyHieght)
        {
            Destroy(projectile);
        }
    }
}
