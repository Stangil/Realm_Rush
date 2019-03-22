using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 30;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip damageSFX;
    [SerializeField] AudioClip destroySFX;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
        audioSource.PlayOneShot(damageSFX);
        hitParticlePrefab.Play();
    }
     void ProcessDeath()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        AudioSource.PlayClipAtPoint(destroySFX, FindObjectOfType<Camera>().transform.position);
        //Debug.Break();
        Destroy(vfx.gameObject, vfx.main.duration);     
        Destroy(gameObject);
    }
}