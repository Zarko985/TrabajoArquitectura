using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunSpawner : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField]
    ObjectPooling objectPooler;
    public bool isActive;

    private void Start()
    {
        objectPooler = ObjectPooling.call;
    }

    private void Update()
    {
        if(!isActive)
        {
            Invoke("spawn", 2f);
            isActive = true;
        }
       
    }

    void spawn()
    {
        objectPooler.SpawnFromPool("Ammo", transform.position, Quaternion.identity);
    }
}
