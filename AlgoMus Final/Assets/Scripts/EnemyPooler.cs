using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{

    //This script is for the Platform pooler that
    //will spawn objects
    [SerializeField]
    private GameObject oneNote;
    [SerializeField]
    private GameObject twoNote;

    [SerializeField]
    private Transform topSpawnPoint;
    [SerializeField]
    private Transform midSpawnPoint;
    [SerializeField]
    private Transform botSpawnPoint;

    public static EnemyPooler Instance;
    private Queue<GameObject> availableEnemies = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public GameObject GetFromPool()
    {
        if(availableEnemies.Count == 0)
        {
            GrowPool();
        }

        var instance = availableEnemies.Dequeue();

        //set to botOrigin for testing purposes
        instance.transform.position = botSpawnPoint.position;
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        //oneNote chosen as test value
        var enemyToBeAdded = Instantiate(oneNote);
        AddPool(enemyToBeAdded);
    }

    public void AddPool(GameObject enemy)
    {
        enemy.SetActive(false);
        availableEnemies.Enqueue(enemy);
    }
}
