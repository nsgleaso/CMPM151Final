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
    private int tracker;

    public static EnemyPooler Instance;
    private Queue<GameObject> availableEnemies = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }


    //Checks if pool is empty
    //if so, then call GrowPool() and continue
    //if not, dequeue object from pool
    //activate it and return it
    public GameObject GetFromPool()
    {
        if(availableEnemies.Count == 0)
        {
            GrowPool();
        }

        var instance = availableEnemies.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    //Creates platform and sends it to AddPool()
    private void GrowPool()
    {
        //get random value to decide what 
        //platform to make next
        int enemyChooser = Randomize();

        if(enemyChooser == 0)
        {
            var enemyToBeAdded = Instantiate(oneNote);
            AddPool(enemyToBeAdded);
        }
        else
        {
            var enemyToBeAdded = Instantiate(twoNote);
            AddPool(enemyToBeAdded);
        }
        
    }

    //Adds deactivated game objects to the queue to 
    //make them available for use later
    public void AddPool(GameObject enemy)
    {
        enemy.SetActive(false);
        availableEnemies.Enqueue(enemy);
    }

    private int Randomize()
    {
        int platformNumber = Random.Range(1, 10);
        if (platformNumber < 8)
        {
            return 0;
        }
        else
        {
            return 1;
        }

    }
}
