using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    // Establecimiento de las variables necesarias para el funcionamiento del script.
    [Header("Variables")]
    [SerializeField] 
    public float Destruccion;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Destruccion del GameObject al cabo de determinado tiempo.
    void Update()
    {

        DestroyGameObject();
    }
    //Detecctor de colision con trigger en el que se detruye el proyectil y reduccion 
    //de la vida del player.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "wall")
        {


            Destroy(gameObject);

        }
        if (other.transform.tag == "Player")
        {
            GameManager.singleton.vidaPlayer -= damage;
            Destroy(gameObject);
        }
       
    }
   
    //En esta funcion llamamos a la destruccion del objeto en cierto momento.
    void DestroyGameObject()
    {

        Destroy(gameObject, Destruccion);


    }
}
