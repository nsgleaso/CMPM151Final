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
    private Transform topOrigin;
    [SerializeField]
    private Transform midOrigin;
    [SerializeField]
    private Transform botOrigin;

    private int tracker;

    public static PlatformPooler Instance;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Start()
    {
        Instance = this;
    }


    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availableObjects.Dequeue();

        //set to botOrigin for testing purposes
        instance.transform.position = botOrigin.position;
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        //longPlat chosen as test value
        var instanceToAdd = Instantiate(longPlat);
        AddPool(instanceToAdd);
    }

    //Adds deactivated game objects to the queue to 
    //make them available for use
    public void AddPool(GameObject platform)
    {
        platform.SetActive(false);
        availableObjects.Enqueue(platform);
    }
}
