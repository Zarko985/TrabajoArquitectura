using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField]
    MunSpawner spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            GameManager.singleton.municion += 10;

            this.gameObject.SetActive(false);

            spawn = GameObject.Find("AmmoSpawn").GetComponent<MunSpawner>();
            spawn.isActive = false;

        }

        
    }
}
