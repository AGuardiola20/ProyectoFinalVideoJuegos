using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D v)
    {
        if (v.CompareTag("Player"))
        {
            PlayerMovement player = v.GetComponent<PlayerMovement>();
            if (player.sumarVida()) Destroy(gameObject);
        }
        
        
    }
}
