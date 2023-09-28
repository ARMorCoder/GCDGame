using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody2D rb;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveTransform(Vector3 vel){
        transform.position += vel * speed *Time.deltaTime;
        //Since the movement isn't following the framerate, we don't need to factor the Time.deltaTime into the calculations.
    }

    public void MoveRB(Vector3 vel){
        rb.velocity = vel * speed;
        if(vel.magnitude > 0){
            if(vel.y < 0){
                animationStateChanger.ChangeAnimationState("FrontWalk", speed/5);
            }else if (vel.y > 0){
                animationStateChanger.ChangeAnimationState("BackWalk", speed/5);
            }else if(vel.x > 0){
                body.localScale = new Vector3(1, 1, 1);
                animationStateChanger.ChangeAnimationState("LRWalk", speed/5);

            }else if(vel.x < 0){
                body.localScale = new Vector3(-1, 1, 1);
                animationStateChanger.ChangeAnimationState("LRWalk", speed/5);
            }
        }else{
            animationStateChanger.ChangeAnimationState("FrontIdle");
        }
        //rb.MovePosition(transform.position + (vel * (Time.fixedDeltaTime * speed)));
        //rb.AddForce(vel);
    }
}
