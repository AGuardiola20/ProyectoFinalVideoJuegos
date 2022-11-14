using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject nokey;
    public GameObject key;

    //public GameObject btnPuerta;


    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
        nokey.SetActive(false);
        //btnPuerta.SetActive(false);
    }

    //Hace la accion cuando tocamos el collider
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("key")){
            AbrirPuerta.llave += 1;
            Destroy(other.gameObject);
        }
    }

    //Hace la accion cuando estamos en el collider
    private void OnTriggerStay2D(Collider2D other){
        if(other.tag.Equals("door") && AbrirPuerta.llave == 0){
            nokey.SetActive(true);
        }

        if(other.tag.Equals("door") && AbrirPuerta.llave == 1){
            key.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                
            }
        }
    }
    //Hace la accion cuando salimos del collider
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag.Equals("door") && AbrirPuerta.llave == 0){
            nokey.SetActive(false);
        }

        if(other.tag.Equals("door") && AbrirPuerta.llave == 1){
            key.SetActive(false);
        }
    }

}

