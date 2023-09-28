using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
   [SerializeField] Movement movement;
   [SerializeField] int health;
   [SerializeField] int energy;
   [SerializeField] Transform body;
   ProjectileThrower pT;

    void Awake(){
       pT = GetComponent<ProjectileThrower>();
        health = 25;
        energy = 15;

    }

    void Start(){
       // pointsHandler = PointsHandler.singleton; //second fastest option
        Debug.Log("Game Start\n");
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            pT.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void FixedUpdate(){
        Vector3 vel =  Vector3.zero;

        if(Input.GetKey(KeyCode.D)){
            vel.x = 1.0f;
        }
        if(Input.GetKey(KeyCode.A)){
            vel.x = -1.0f;
        }
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1.0f;
        }
        if(Input.GetKey(KeyCode.S)){
            vel.y = -1.0f;
        }
        movement.MoveRB(vel);
    }

    public void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "EnemyBullet"){
            Debug.Log("I've been hit!");
            health--;
        }
    }
}
