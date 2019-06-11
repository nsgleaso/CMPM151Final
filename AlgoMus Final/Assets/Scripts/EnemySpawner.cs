using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float timer;
    [SerializeField]
    private float delay;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform topSpawnPoint;
    [SerializeField]
    private Transform midSpawnPoint;
    [SerializeField]
    private Transform botSpawnPoint;

    private Vector3 lastPosition;
    private int offset = 20;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFromPool();
        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            timer = 0;
            SpawnFromPool();
        }
    }

    private void SpawnFromPool()
    {
        var enemy = EnemyPooler.Instance.GetFromPool();
        Reposition(enemy);
    }

    //repositions spawned platform
    private void Reposition(GameObject enemy)
    {
        int decider = Random.Range(0, 9);
        if(decider < 3)
        {
            SpawnFromBot(enemy);
        }else if(decider > 3 && decider < 7)
        {
            SpawnFromMid(enemy);
        }
        else
        {
            SpawnFromTop(enemy);
        }

    }

    private void SpawnFromBot(GameObject enemy)
    {

        enemy.transform.position = new Vector3(lastPosition.x + offset,
            botSpawnPoint.position.y);
        lastPosition = enemy.transform.position;
        //tracker = 0;

    }

    private void SpawnFromMid(GameObject enemy)
    {

        enemy.transform.position = new Vector3(lastPosition.x + offset,
            midSpawnPoint.position.y);
        lastPosition = enemy.transform.position;
        //tracker = 1;
    }

    private void SpawnFromTop(GameObject enemy)
    {


        enemy.transform.position = new Vector3(lastPosition.x + offset,
            topSpawnPoint.position.y);

        lastPosition = enemy.transform.position;
        //tracker = 2;
    }


}
