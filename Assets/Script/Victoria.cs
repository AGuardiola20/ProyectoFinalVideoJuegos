using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    Nivel[] niveles;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            victoria();
        }
    }


    public void victoria()
    {
        cargarNiveles();
        
        foreach (Nivel n in niveles)
        {
            if (PlayerPrefs.GetInt(n.nivel) == 0)
            {
                PlayerPrefs.SetInt(n.nivel, 1);
                break;
            }
        }
        foreach (Nivel n in niveles)
        {
            if (PlayerPrefs.GetInt(n.nivel) == 0)
            {
                iniciarPartida();
                return;
            }
        }

    }
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

    public void iniciarPartida()
    {
        cargarNiveles();

        foreach (Nivel n in niveles)
        {
            //PlayerPrefs.SetInt(n.nivel, 0);
            if (PlayerPrefs.GetInt(n.nivel) == 0)
            {
                PlayerPrefs.SetFloat("checkPositionX", n.posIniX);
                PlayerPrefs.SetFloat("checkPositionY", n.posIniY);
                CambiarEcenaClick(n.nivel);
                break;

            }
        }

    }
    public void CambiarEcenaClick(string sceneName)
    {

        StartCoroutine(retrasoEscena(sceneName));
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    IEnumerator retrasoEscena(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
}
