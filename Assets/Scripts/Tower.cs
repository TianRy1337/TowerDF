using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [Range(10, 50)]
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] float distaceToEnemy;

    Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            FireAtEnemy();
            objectToPan.LookAt(targetEnemy);
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }
        Transform closesEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closesEnemy = GetClosest(closesEnemy, testEnemy.transform);
        }

        targetEnemy = closesEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var disToA = Vector3.Distance(transform.position, transformA.position);
        var disToB = Vector3.Distance(transform.position, transformB.position);

        if (disToA > disToB)
        {
            return transformB;
        }
        else { return transformA; }

    }

    void FireAtEnemy()
    {
        Vector3 tower = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 enemy = new Vector3(targetEnemy.position.x, targetEnemy.position.y, targetEnemy.position.z);
        distaceToEnemy = Vector3.Distance(tower, enemy);
        if (distaceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
        //print("I'm " + gameObject.name +" My Distance to Enemy is "+ Vector3.Distance(tower, enemy));
    }
    void Shoot(bool isActive)
    {
        var emissonModule = projectileParticle.emission;
        emissonModule.enabled = isActive;
    }
}
