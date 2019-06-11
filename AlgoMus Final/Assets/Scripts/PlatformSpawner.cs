using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform topOrigin;
    [SerializeField]
    private Transform midOrigin;
    [SerializeField]
    private Transform botOrigin;

    private Vector3 lastPosition;

    private float timer;
    [SerializeField]
    private float delay;

    private int tracker;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFromPool();
        tracker = 0;
        lastPosition = new Vector3(player.transform.position.x + 10,
            topOrigin.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > delay)
        {
            timer = 0;
            SpawnFromPool();
        }
    }

    
    private void SpawnFromPool()
    {

        var platform = PlatformPooler.Instance.GetFromPool();
        Reposition(platform);
        
        
    }

    //repositions spawned platform
    private void Reposition(GameObject platform)
    {
        //if previous platform was at bottom
        //spawn in mid because top is unreachable
        if (tracker == 0)
        {
            SpawnFromMid(platform);
            return;
        }

        int random = Random.Range(0, 9);
        if (random < 5)
        {
            SpawnFromBot(platform);
        }
        else
        {
            SpawnFromTop(platform);
        }


    }

    private void SpawnFromBot(GameObject platform)
    {
        int offset = GetOffset(platform.tag);

        platform.transform.position = new Vector3(lastPosition.x + offset,
            botOrigin.position.y);
        lastPosition = platform.transform.position;
        tracker = 0;

    }

    private void SpawnFromMid(GameObject platform)
    {
        int offset = GetOffset(platform.tag);

        platform.transform.position = new Vector3(lastPosition.x + offset,
            midOrigin.position.y);
        lastPosition = platform.transform.position;
        tracker = 1;
    }

    private void SpawnFromTop(GameObject platform)
    {
        int offset = GetOffset(platform.tag);


        platform.transform.position = new Vector3(lastPosition.x + offset,
            topOrigin.position.y);

        lastPosition = platform.transform.position;
        tracker = 2;
    }

    private int GetOffset(string tag)
    {
        int offset = 0;  
        if(tag == "ShortPlatform")
        {
            Debug.Log("shortPlatform spawned");
            offset = 5;
        }else if(tag == "MediumPlatform")
        {
            offset = 7;
        }
        else
        {
            offset = 10;
        }

        return offset;
    }

}
