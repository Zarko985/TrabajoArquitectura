using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    [Header("Componentes")]
    [SerializeField]
    public Rigidbody rb;
    public Camera cam;
    

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

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        CameraMove();
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime); 
    }

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
