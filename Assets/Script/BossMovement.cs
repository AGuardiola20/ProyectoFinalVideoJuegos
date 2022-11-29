using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;

    //Se usa cuando el state empieza
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    //Se usa cuando el state se esta ejecutando
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    //Se usa cuando el state termina
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        
    }

}
