using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D v) {
        PlayerMovement player = v.GetComponent<PlayerMovement>();
        Enemy enemy = v.GetComponent<Enemy>();
        if(player != null){
            player.Hit();
        }
        if(enemy != null){
            enemy.Hit();
        }
        DestroyBullet();
    }

    /*
    private void OnCollisionEnter2D(Collision2D v) {
        PlayerMovement player = v.collider.GetComponent<PlayerMovement>();
        Enemy enemy = v.collider.GetComponent<Enemy>();
        if(player != null){
            player.Hit();
        }
        if(enemy != null){
            enemy.Hit();
        }
        DestroyBullet();
    }
    */
}
