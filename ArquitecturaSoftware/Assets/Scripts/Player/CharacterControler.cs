using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    //Componentes necesarios para el funcionamiento
    //del script
    [Header("Componentes")]
    [SerializeField]
    public Rigidbody rb;
    public Camera cam;
    
    //Variables necesarias para que el controlador
    //pueda moverse o establecer la velocidad
    [Header("Variables")]
    [SerializeField]
    private float Speed = 5f;
    float hitDist = 0.0f;
    private Vector3 movement;
    Quaternion targetRotation;
    Ray ray;
    Vector3 targetPoint;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Deteccion para saber en que direccion se desea 
    // que el personaje se mueva y su vista.
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        CameraMove();
        
    }
    //Limitador de Velocidad del personaje
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime); 
    }
    //Establecimiento de la vista mediante el uso de raycast para saber la posicion del raton
    // y hacia que posicion debe girar el personaje.
    void CameraMove()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(playerPlane.Raycast(ray, out hitDist))
        {
            targetPoint = ray.GetPoint(hitDist);
            targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }
}
