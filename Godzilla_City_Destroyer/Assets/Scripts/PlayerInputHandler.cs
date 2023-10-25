using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
   [SerializeField] Movement movement;
   public int health = 1;
   [SerializeField] int energy;
   [SerializeField] Transform body;
   [SerializeField] Text healthText;
   [SerializeField] Text energyText;
   ProjectileThrower pT;
   [SerializeField] AttackAnimationChanger aac;
   [SerializeField] GameObject attack;
   [SerializeField] FootAttackAnimationStateChanger fac;
   [SerializeField] GameObject footAttack;

    void Awake(){
        attack.GetComponent<SpriteRenderer>().enabled = false;
        footAttack.GetComponent<SpriteRenderer>().enabled = false;
        pT = GetComponent<ProjectileThrower>();
        //change later
        health = 20;
        energy = 10;

    }

    void Start(){
        Debug.Log("Game Start\n");
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
        RegenerateEnergy();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(energy <= 0){
                Debug.Log("out of energy!!");
             }else{ 
                pT.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition)
                );
                energy -= 1;
             }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
           attack.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
           attack.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.V)){
            footAttack.GetComponent<SpriteRenderer>().enabled = true;
        }if(Input.GetKeyUp(KeyCode.V)){
            footAttack.GetComponent<SpriteRenderer>().enabled = false;
        }
        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
    }

    void RegenerateEnergy(){
        StartCoroutine(RegenerateEnergyRoutine());
        IEnumerator RegenerateEnergyRoutine(){
            while(true){
                yield return new WaitForSeconds(4);
                if(energy >= 10){
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
        }else if(obj.tag == "energyPoint"){
            AudioSource audio = obj.GetComponent<AudioSource>();
            audio.Play();
            energy += 3;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }
    }
}
