using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    //Establecimiento de los componentes 
    //Llamada al script MunSpawner
    [Header("Componentes")]
    [SerializeField]
    MunSpawner spawn;

    //Trigger para establecer que cuando el jugador colisione con la caja de municion
    //esta se desactive y añada más munición al jugador.
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
