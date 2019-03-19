using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    void Update()
    {
        if (targetEnemy)
        {
            lookAtEnemy();
            fireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void lookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }

    void fireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        //print("distance: " + distanceToEnemy);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool v)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = v;
    }
}
