using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputBossLevel : MonoBehaviour
{
    [SerializeField] MovementBossLevel movement;
    public int health = 1;
    [SerializeField] int energy;
    //[SerializeField] Transform body;
    [SerializeField] Text healthText;
    [SerializeField] Text energyText;
    ProjectileThrowerBossLevel pT;

    void Awake(){
        pT = GetComponent<ProjectileThrowerBossLevel>();
        //change later 
        health = 5;
        energy = 15;

    }
    void Start(){
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
        RegenerateEnergy();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(energy <= 0){
                Debug.Log("out of energy!!");
             }else{ 
                pT.Throw();
                energy -= 1;
             }
        }
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
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
       /* if(Input.GetKey(KeyCode.W)){
            vel.y = 1.0f;
        }
        if(Input.GetKey(KeyCode.S)){
            vel.y = -1.0f;
        }*/
        //movement.MoveTransform(vel);
        movement.MoveRB(vel);

    }
        public void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "EnemyBullet"){
            Debug.Log("I've been hit!");
            health--;
            Destroy(obj.gameObject);
        }else if(obj.tag == "EnemyMelee"){
            Debug.Log("I've been hit!");
            health--;
        }
    }
}
