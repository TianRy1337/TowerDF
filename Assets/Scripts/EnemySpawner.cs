using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweensSpawns = 2f;
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    private void Start() 
    {
        StartCoroutine(RepeatedlySpawnEnemies());    
    }
    
    IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            var enemy = Instantiate(EnemyPrefab,transform.position,Quaternion.identity);
            enemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSecondsRealtime(secondsBetweensSpawns);
        }
    }


    
}
