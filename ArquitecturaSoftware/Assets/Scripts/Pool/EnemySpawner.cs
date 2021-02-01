using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    public GameObject spawnEnemigo;
    ObjectPooling objectPooler;
    public bool isActive;

    void Start()
    {
        objectPooler = ObjectPooling.call;
    }

    void Update()
    {

        if (!isActive)
        {
            Invoke("spawnEnemy", 5f);
            isActive = true;
        }

    }

    void spawnEnemy()
    {
        objectPooler.SpawnFromPool("Enemy", spawnEnemigo.transform.position, Quaternion.identity);
    }
}
