using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 30;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    private void OnParticleCollision(GameObject other)
    {
       
        ProcessHit();
        if (hitPoints < 1)
        {
            ProcessDeath();
        }
    }

    void ProcessHit()
    {      
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
    void ProcessDeath()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(gameObject);
        //TODO add coroutine to destroy deathParticlePrefab
    }
}
