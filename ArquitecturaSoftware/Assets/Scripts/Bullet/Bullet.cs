using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    

    [Header("Variables")]
    [SerializeField] 
    public float Destruccion;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, Destruccion);
    }

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
   

    void DestroyGameObject()
    {

        Destroy(gameObject, Destruccion);


    }
}
