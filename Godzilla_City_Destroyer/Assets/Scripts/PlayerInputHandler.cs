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
        RegenerateEnergy();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(energy <= 0){
                Debug.Log("out of energy!!");
             }else{ 
                pT.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                energy -= 1;
             }
        }
    }

    void RegenerateEnergy(){
        StartCoroutine(RegenerateEnergyRoutine());
        IEnumerator RegenerateEnergyRoutine(){
            while(true){
                yield return new WaitForSeconds(4);
                if(energy == 15){
                    Debug.Log("FULL ENERGY!!!");
                }else{
                    energy += 1;
                }
            }

            yield return null;
            
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
            Destroy(obj.gameObject);
        }
    }
}
