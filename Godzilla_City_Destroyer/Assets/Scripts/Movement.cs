using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveTransform(Vector3 vel){
        transform.position += vel * speed *Time.deltaTime;
        //Since the movement isn't following the framerate, we don't need to factor the Time.deltaTime into the calculations.
    }

    public void MoveRB(Vector3 vel){
        //rb.velocity = vel;
        rb.MovePosition(transform.position + (vel * (Time.fixedDeltaTime * speed)));
        //rb.AddForce(vel);
    }
}
