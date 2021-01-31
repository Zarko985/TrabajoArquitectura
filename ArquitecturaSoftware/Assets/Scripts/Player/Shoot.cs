using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Componentes")]
    [SerializeField]
    public GameObject bulletPrefab;
    
   

    [Header("Variables")]
    [SerializeField]
    Transform firePoint;
    public float bulletForce = 20f;
    private float nextTimeToShoot = 0f;
    public float FireRate;



    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    void disparo()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
