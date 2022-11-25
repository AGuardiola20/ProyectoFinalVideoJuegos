using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenas : MonoBehaviour
{
    public Nivel[] niveles;
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

    public void iniciarPartida()
    {
        cargarNiveles();

        foreach (Nivel n in niveles)
        {
            //PlayerPrefs.SetInt(n.nivel, 0);
            if (PlayerPrefs.GetInt(n.nivel)==0)
            {
                PlayerPrefs.SetFloat("checkPositionX", n.posIniX);
                PlayerPrefs.SetFloat("checkPositionY", n.posIniY);
                CambiarEcenaClick(n.nivel);
                break;
               
            }
        }

    }

    public void nuevaPatida()
    {
        cargarNiveles();

        foreach (Nivel n in niveles)
        {
            PlayerPrefs.SetInt(n.nivel, 0);
            if (PlayerPrefs.GetInt(n.nivel) == 0)
            {
                PlayerPrefs.SetFloat("checkPositionX", n.posIniX);
                PlayerPrefs.SetFloat("checkPositionY", n.posIniY);
                CambiarEcenaClick("Trans");
                break;

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
}
