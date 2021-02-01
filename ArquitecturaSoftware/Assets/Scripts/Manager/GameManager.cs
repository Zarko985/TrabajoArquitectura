using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Establecimiento de los diversos componentes 
    //necesarios para el proyecto.
    [Header("Componentes")]
    [SerializeField]
    public static GameManager singleton;
    public Text MuniText;
    public Text vidaText;
    public Text puntosText;
    public Text FinalText;

    //Variables necesarias en el proyecto.
    [Header("Variables")]
    [SerializeField]
    public int municion;

    //Variables exclusivas del Player
    [Header("Player")]
    [SerializeField]
    public int vidaPlayer;

    //Variables exclusivas del enemigo
    [Header("Enemies")]
    [SerializeField]
    public int puntos;


    //Establecimiento del Singleton para poder llamar las variables
    // y componentes necesarios en otros Scripts.
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

    //Elementos basicos que deben estar establecidos para el inicio de la partida.
    // Start is called before the first frame update
    void Start()
    {
        municion = 10;
        vidaPlayer = 3;
        puntos = 0;

    }

    //Actualizacion de variables
    // Update is called once per frame
    void Update()
    {
        textos();
         
    }

    //Actualizacion de los diversos textos que se usan en la UI
    // asi como la victoria y la derrota y el timeScale.
    void textos()
    {

        MuniText.text = "Municion: " + municion;
        vidaText.text = "Vidas Restantes: " + vidaPlayer;
        puntosText.text = "Puntuacion: " + puntos;

        if ((puntos >= 5) & (vidaPlayer > 0))
        {
            FinalText.text = "VICTORIA";
            Time.timeScale = 0;

        }
        if((puntos < 5) & (vidaPlayer <= 0))
        {
            FinalText.text = "DERROTA";
            Time.timeScale = 0;
        }





    }

 

}
