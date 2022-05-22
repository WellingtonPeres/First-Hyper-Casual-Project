using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs controller")]
    [SerializeField] private Vector2 rangeEnemies;
    [SerializeField] private Vector2 rangeBonus;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bonusPrefab;

    [Header("List of enemies")]
    [SerializeField] private int amountEnemiesInScene = 5;
    [SerializeField] private int amountBonusInscene = 5;
    [SerializeField] private List<GameObject> listEnemiesPooling;
    [SerializeField] private List<GameObject> listBonusPooling;

    private void Start()
    {
        InstantiateEnemiesOrBonusInScene(amountEnemiesInScene, enemyPrefab, listEnemiesPooling);
        InstantiateEnemiesOrBonusInScene(amountBonusInscene, bonusPrefab, listBonusPooling);

        StartCoroutine(SpawnEnemyPooling());
        StartCoroutine(SpawnBonusPooling());
    }

    private void InstantiateEnemiesOrBonusInScene(int amountObjects, GameObject objectPrefab,List<GameObject> listObjects)
    {
        for (int i = 0; i < amountObjects; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            listObjects.Add(newObject);
            newObject.SetActive(false);
        }
    }

    private IEnumerator SpawnEnemyPooling()
    {
        yield return new WaitForSeconds(1);

        ActiveObjectsInScenePooling(amountEnemiesInScene, listEnemiesPooling, rangeEnemies);

        StartCoroutine(SpawnEnemyPooling());
    }

    private IEnumerator SpawnBonusPooling()
    {
        yield return new WaitForSeconds(1.5f);

        ActiveObjectsInScenePooling(amountBonusInscene, listBonusPooling, rangeBonus);

        StartCoroutine(SpawnBonusPooling());
    }

    private void ActiveObjectsInScenePooling(int amountObjects, List<GameObject> listObjects, Vector2 randRange)
    {
        for (int i = 0; i < amountObjects; i++)
        {
            Vector2 enemySpawnPosition = transform.position + new Vector3(0, Random.Range(-randRange.y, randRange.y));
            if (!listObjects[i].activeSelf)
            {
                listObjects[i].SetActive(true);
                listObjects[i].transform.position = enemySpawnPosition;

                break;
            }
        }
    }
}
