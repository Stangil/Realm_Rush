using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 30;
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
    }
    void ProcessDeath()
    {
        Destroy(gameObject);
    }
}
