using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField]
    public Transform target;
    public Transform moveEnemy;
    public Transform MovePoint;
    public Transform firePoint;
    public GameObject bulletPrefab;
    EnemySpawner Enemigo;

    [Header("Variables")]
    [SerializeField]
     private float nextTimeToShoot = 0f;
     public float cadencia;
     public float DistanciaDisparo;
     public float Speed;
     public float bulletForce = 20f;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        MovePoint = GameObject.Find("RP").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        lookAt();
        enemyMove();
        disparoEnemy();
    }


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

    void InitialPosition()
    {

        Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), 0.05f);
        transform.rotation = lerpRotation;
    }


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

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "bullet")
        {
            GameManager.singleton.puntos += 1;
            Enemigo = GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>();
            Enemigo.isActive = false;
            this.gameObject.SetActive(false);

        }
    }

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
