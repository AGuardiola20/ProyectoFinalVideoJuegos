using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float LastShoot;

    public GameObject Player;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x > 0.0f) transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);

        //Mathf.Abs(x + y) = Conseguir num positivo con el valor absoluto
        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.60f){
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot(){
        //Debug.Log("Enemy Shoot");
        Vector3 direction;

        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}
