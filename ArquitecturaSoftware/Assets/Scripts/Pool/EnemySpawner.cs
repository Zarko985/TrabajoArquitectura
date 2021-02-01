using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    public GameObject spawnEnemigo;
    ObjectPooling objectPooler;
    public float contador;
    

    void Start()
    {
        objectPooler = ObjectPooling.call;
    }

    void Update()
    {
        contador += Time.deltaTime;

        if(contador >= 5)
        {
            
            spawnEnemy();
            contador = 0;
            
        }
        

    }

    public void spawnEnemy()
    {
        objectPooler.SpawnFromPool("Enemy", spawnEnemigo.transform.position, Quaternion.identity);
    }

    
}
