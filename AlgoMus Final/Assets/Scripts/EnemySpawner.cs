using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float timer;
    [SerializeField]
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFromPool();
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
    }
}
