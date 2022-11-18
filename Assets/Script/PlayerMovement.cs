using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private Animator animator;
    private float LastShoot;

    //Vida
    private int Health = 5;

    //Teleport
    private GameObject currentTeleporter;

    public float JumpForce;
    public float Speed;
    public GameObject BulletPrefab;
    
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

        //Turn around
        if(Horizontal < 0.0f)transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f)transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
        //Run Animation
        animator.SetBool("running", Horizontal != 0.0f);

        //Condicional para que avise si esta en el suelo
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }else Grounded = false;
        
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && Grounded){
            Jump();
        }

        //Checkpoint
        if(Input.GetKeyDown(KeyCode.R)){
            Restart();
        }

        //Disparo
        if (Input.GetKeyDown(KeyCode.F) && Time.time > LastShoot + 0.45f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        //Tp
        if(Input.GetKeyDown(KeyCode.E)){
            if(currentTeleporter != null){
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    //Tp
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Teleporter")){
            currentTeleporter = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Teleporter")){
            if(other.gameObject == currentTeleporter){
                currentTeleporter = null;
            }
        }
    }

    //Jump
    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    //Cuando se trabaja con fisicas es mejor utilizar FixedUpdate()
    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    //Shoot
    private void Shoot(){
        Vector3 direction;

        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    //Hit
    public void Hit(){
        GameObject.FindWithTag("vida"+Health).SetActive(false);
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
    }

    //Restart position
    void Restart()
    {
        transform.position = (new Vector2(0.187f, -0.135f));
    }

}
