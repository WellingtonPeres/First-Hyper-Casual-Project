using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 rangeEnemys;
    [SerializeField] private Vector2 rangeBonus;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bonusPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        Vector2 spawnPosition = transform.position + new Vector3(0, Random.Range(-rangeEnemys.y, rangeEnemys.y));
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(1.5f);
        Vector2 spawnPosition = transform.position + new Vector3(0, Random.Range(-rangeBonus.y, rangeBonus.y));
        Instantiate(bonusPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnBonus());
    }
}
