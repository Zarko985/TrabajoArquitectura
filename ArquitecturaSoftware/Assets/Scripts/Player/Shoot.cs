using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    //Recopilacion de los componentes para 
    //el uso del script.
    [Header("Componentes")]
    [SerializeField]
    public GameObject bulletPrefab;
   
    //Variables que delimitan la cadencia de disparo
    //fuerza o el punto de salida del proyectil.
    [Header("Variables")]
    [SerializeField]
    Transform firePoint;
    public float bulletForce = 20f;
    private float nextTimeToShoot = 0f;
    public float FireRate;


    //Detecta que si la municion es 0 no permite disparar mas 
    // y si quedan protectiles si puedes.
    // Update is called once per frame
    void Update()
    {
        if(GameManager.singleton.municion > 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1f / FireRate;
                GameManager.singleton.municion -= 1;
                disparo();
            }
        }

       
        
    }
    //Establecimiento de la trayectoria y potencia del disparo
    //mediante el uso del rigidbody.
    void disparo()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
