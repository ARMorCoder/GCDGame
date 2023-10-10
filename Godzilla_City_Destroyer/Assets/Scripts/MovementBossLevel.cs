using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBossLevel : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveRB(Vector3 vel){
        //rb.velocity = vel;
        if(vel.x > 0 || vel.x < 0){
            animationStateChanger.ChangeAnimationState("BackWalk", speed/5);
        }else{
            animationStateChanger.ChangeAnimationState("BackIdle", speed/5);
        }
        rb.MovePosition(transform.position + (vel * (Time.fixedDeltaTime * speed)));
        //rb.AddForce(vel);
    }
}
