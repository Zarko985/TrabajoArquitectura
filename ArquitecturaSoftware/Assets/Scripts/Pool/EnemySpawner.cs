using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //Variables necesarias para que el spawner
    //funcione correctamente.

    [Header("Variables")]
    [SerializeField]
    public GameObject spawnEnemigo;
    ObjectPooling objectPooler;
    public float contador;
    
    //llamada al singleton del pool de objetos
    void Start()
    {
        objectPooler = ObjectPooling.call;
    }

    //Establece un contador de que cada 5s, aparece un nuevo enemigo en el spawner.
    void Update()
    {
        contador += Time.deltaTime;

        if(contador >= 5)
        {
            
            spawnEnemy();
            contador = 0;
            
        }
        

    }
    //Se marca el GameObject que quermos spawnear y en que posicion.
    public void spawnEnemy()
    {
        objectPooler.SpawnFromPool("Enemy", spawnEnemigo.transform.position, Quaternion.identity);
    }

    
}
