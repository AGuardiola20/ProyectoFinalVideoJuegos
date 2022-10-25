using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private Animator animator;

    public float JumpForce;
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxisRaw(x) = Se obtienen valores en funcion de la tecla que pulse la persona
        Horizontal = Input.GetAxisRaw("Horizontal");
        
        animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        //Condicional para que avise si esta en el suelo
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }else Grounded = false;
        
        if(Input.GetKeyDown(KeyCode.Space) && Grounded){
            Jump();
        }

    }

    //Cuando se trabaja con fisicas es mejor utilizar FixedUpdate()
    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

}
