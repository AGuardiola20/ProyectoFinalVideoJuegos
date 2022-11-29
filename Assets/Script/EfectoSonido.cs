using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    [SerializeField] private AudioClip sonido1;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ControladorSonido.Instance.EjecutarSonido(sonido1);
            Destroy(gameObject);
        }
    }
    
}
