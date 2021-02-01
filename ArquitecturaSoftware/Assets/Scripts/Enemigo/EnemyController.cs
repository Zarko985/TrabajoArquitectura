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
    

    [Header("Variables")]
    [SerializeField]
     public float DistanciaDisparo;
    public float Speed;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookAt();
        enemyMove();
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
}
