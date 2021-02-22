using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [Range(10, 50)]
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField]float distaceToEnemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy)
        {
        FireAtEnemy();
        objectToPan.LookAt(targetEnemy);
        }else
        {
            Shoot(false);
        }
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
