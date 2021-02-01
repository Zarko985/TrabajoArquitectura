﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField]
    public static GameManager singleton;
    public Text MuniText;
    public Text vidaText;
    public Text puntosText;
    public Text FinalText;

    [Header("Variables")]
    [SerializeField]
    public int municion;

    [Header("Player")]
    [SerializeField]
    public int vidaPlayer;

    [Header("Enemies")]
    [SerializeField]
    public int vidaEnemies;
    public int puntos;



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
        vidaPlayer = 3;
        vidaEnemies = 1;
        puntos = 0;

    }

    // Update is called once per frame
    void Update()
    {
        textos();
         
    }

    void textos()
    {

        MuniText.text = "Municion: " + municion;
        vidaText.text = "Vidas Restantes: " + vidaPlayer;
        puntosText.text = "Puntuacion: " + puntos;

        if ((puntos >= 50) & (vidaPlayer > 0))
        {
            FinalText.text = "VICTORIA";

        }
        if((puntos < 50) & (vidaPlayer <= 0))
        {
            FinalText.text = "DERROTA";
        }





    }

 

}
