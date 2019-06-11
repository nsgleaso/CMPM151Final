using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{

    //This script is for the Platform pooler that
    //will spawn objects
    [SerializeField]
    private GameObject longPlat;
    [SerializeField]
    private GameObject medPlat;
    [SerializeField]
    private GameObject shortPlat;

    [SerializeField]
    private int tracker;

    public static PlatformPooler Instance;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

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
        if(availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availableObjects.Dequeue();

        instance.SetActive(true);
        return instance;
    }


    //Creates platform and sends it to AddPool()
    private void GrowPool()
    {
        //get random value to decide what 
        //platform to make next
        int platformChooser = Randomize();

        if(platformChooser == 0)
        {
            var instanceToAdd = Instantiate(shortPlat);
            AddPool(instanceToAdd);
        }
        else if(platformChooser == 1)
        {
            var instanceToAdd = Instantiate(medPlat);
            AddPool(instanceToAdd);
        }
        else
        {
            var instanceToAdd = Instantiate(longPlat);
            AddPool(instanceToAdd);
        }
        
        
    }

    //Adds deactivated game objects to the queue to 
    //make them available for use later
    public void AddPool(GameObject platform)
    {
        platform.SetActive(false);
        availableObjects.Enqueue(platform);
    }

    private int Randomize()
    {
        int platformNumber = Random.Range(1, 10);
        if (platformNumber < 4)
        {
            return 0;
        }
        else if (platformNumber > 3 && platformNumber < 7)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
