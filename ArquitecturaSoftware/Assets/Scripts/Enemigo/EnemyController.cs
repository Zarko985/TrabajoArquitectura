using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //Establecimiento de los componentes necesarios para el correcto funcionamiento
    //del controlador para establecer rutas o movimientos de este.
    [Header("Componentes")]
    [SerializeField]
    public Transform target;
    public Transform moveEnemy;
    public Transform MovePoint;
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    //Las Variables necesarias para que el controlador pueda disparar
    //, marcar la fuerza del disparo o su cadencia.
    [Header("Variables")]
    [SerializeField]
     private float nextTimeToShoot = 0f;
     public float cadencia;
     public float DistanciaDisparo;
     public float Speed;
     public float bulletForce = 20f;



    // Start is called before the first frame update
    //Establecimiento de la ruta de movimiento y el objetivo al que atacar.
    void Start()
    {
        target = GameObject.Find("Player").transform;
        MovePoint = GameObject.Find("RP").transform;
        
    }

    // Update is called once per frame
    //LLamada continua a las funciones que se le llamen.
    void Update()
    {
        lookAt();
        enemyMove();
        disparoEnemy();
    }

    //Funcion para marcar el punto donde debe mirar el enemigo
    void lookAt()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= DistanciaDisparo)
            {
                transform.LookAt(target);
            }
            else
            {
                InitialPosition();
            }

        }
        else
        {
            InitialPosition();
        }
    }
    //Posicion inicial del enemigo.
    void InitialPosition()
    {

        Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), 0.05f);
        transform.rotation = lerpRotation;
    }

    //Establecimiento del movimiento del enemigo
    void enemyMove()
    {
        moveEnemy.position = Vector3.Lerp(moveEnemy.position, MovePoint.position, Speed * Time.deltaTime);

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, MovePoint.position);

            {
                transform.LookAt(target);
            }


        }
    }
    //Trigger para establecer la desactivacion de los enemigos.
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "bullet")
        {
            GameManager.singleton.puntos += 1;
          
            this.gameObject.SetActive(false);

        }
    }
    //Funcion para establecer el disparo del enemigo
    void disparoEnemy()
    {
        
        if (Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f / cadencia;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

        }

    }
}
