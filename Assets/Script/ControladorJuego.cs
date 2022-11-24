using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public Nivel[] niveles;

    // Start is called before the first frame update
    void Start()
    {
        cargarNiveles();
        partidaComenzada();
        

    }
    private void Update()
    {

        
    }
    

    //Carga los niveles guardados en el json
    public void cargarNiveles()
    {
        try
        {
            niveles =
                JsonConvert.
                DeserializeObject<Nivel[]>(File.
                ReadAllText(Application.streamingAssetsPath +
                "/Niveles.json"));

        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }

        Console.WriteLine(niveles[0].nivel);  

    }

    //Si no existe una partida guardada inicializa los Pref en cero para cada nivel
    //0=false 1=true  el nivel se ha superado o no
    public void partidaComenzada()
    {
        if (PlayerPrefs.GetInt("PrimerNivel")!=1)
        {
            PlayerPrefs.SetInt("PrimerNivel", 0);
            PlayerPrefs.SetInt("SegundoNivel", 0);
            GameObject continuar= GameObject.FindGameObjectWithTag("continuarPartida");
            if (continuar != null) continuar.SetActive(false);

        }
    }


    


}