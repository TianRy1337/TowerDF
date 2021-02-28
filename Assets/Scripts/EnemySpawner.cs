using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweensSpawns = 2f;
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;
    int numEnemies;
    AudioSource myAudioSouce;

    private void Start()
    {
        myAudioSouce = GetComponent<AudioSource>();
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnEnemies.text = numEnemies.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            AddEnemyText();
            myAudioSouce.PlayOneShot(spawnedEnemySFX);
            var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSecondsRealtime(secondsBetweensSpawns);
        }

    }

    public void AddEnemyText()
    {
        numEnemies++;
        spawnEnemies.text = numEnemies.ToString();
    }

}
