using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunSpawner : MonoBehaviour
{
    //Variables necesarias para que el spawner
    //funcione correctamente.
    [Header("Variables")]
    [SerializeField]
    ObjectPooling objectPooler;
    public bool isActive;

    //llamada al singleton del pool de objetos
    private void Start()
    {
        objectPooler = ObjectPooling.call;
    }

    //Deteccion de que si la caja esta activa, no saque otra 
    // y si no esta activa invoca una nueva.
    private void Update()
    {
        if(!isActive)
        {
            Invoke("spawnAmmo", 2f);
            isActive = true;
        }
       
    }
    //Se marca el GameObject que quermos spawnear y en que posicion.
    void spawnAmmo()
    {
        objectPooler.SpawnFromPool("Ammo", transform.position, Quaternion.identity);
    }
}
