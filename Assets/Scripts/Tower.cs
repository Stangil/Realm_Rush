using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

    //State of each tower
    Transform targetEnemy;
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0){ return; }
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(transform.position,transformA.position);//distance from tower to current closestEnemy
        float distToB = Vector3.Distance(transform.position, transformB.position);//distance from tower to next Enemy
        if (distToA < distToB)
        {
            return transformA;
        }
        
            return transformB;
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
