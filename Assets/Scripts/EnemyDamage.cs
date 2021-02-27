using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem HitParticlePrefab;
    [SerializeField] ParticleSystem DiedParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSouce; 

    void Start()
    {
        myAudioSouce = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if(hitPoints <=0)
        {
            KillEnemy();
        }

    }
    void ProcessHit()
    { 
        hitPoints -= 1;
        myAudioSouce.PlayOneShot(enemyHitSFX);
        HitParticlePrefab.Play();
        //print("I'm Hit,Now My Hp is "+hitPoints);
    }
    void KillEnemy()
    {
        var vfx = Instantiate(DiedParticlePrefab,transform.position,Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        AudioSource.PlayClipAtPoint(enemyDeathSFX,Camera.main.transform.position);
        Destroy(vfx.gameObject,destroyDelay);
        Destroy(gameObject);
    }
}
