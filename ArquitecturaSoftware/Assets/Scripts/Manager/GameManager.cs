using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField]
    public static GameManager singleton;

    [Header("Variables")]
    [SerializeField]
    public int municion;


    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            Destroy(this);
        }



    }


    // Start is called before the first frame update
    void Start()
    {
        municion = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
