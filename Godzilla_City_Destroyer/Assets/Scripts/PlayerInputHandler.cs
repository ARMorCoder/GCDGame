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
   [SerializeField] bool timeActive = false;
   [SerializeField] TimeCountDown timer;
   [SerializeField] bool IB = false;//invincibility 

    void Awake(){
        attack.GetComponent<SpriteRenderer>().enabled = false;
        footAttack.GetComponent<SpriteRenderer>().enabled = false;
        pT = GetComponent<ProjectileThrower>();
        //change later
        health = 100;
        energy = 40;

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

        if(timeActive){
            Debug.Log("Time is active!");
            if(timer.secondsLeft == 0 && !timer.done){
                timer.setSeconds(20);
                IB = true;
            }else if(timer.done && timer.secondsLeft == 0){
                timeActive = false;
                IB = false;
                Debug.Log("Time is gone!");
            }

        }
        if(IB){
            body.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(!IB){
            body.GetComponent<SpriteRenderer>().color = Color.white;
        }

        healthText.text = "Health: " + health;
        energyText.text = "Energy: " + energy;
    }

    void RegenerateEnergy(){
        StartCoroutine(RegenerateEnergyRoutine());
        IEnumerator RegenerateEnergyRoutine(){
            while(true){
                yield return new WaitForSeconds(4);
                if(energy >= 40){
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
        if(obj.tag == "EnemyBullet" && !IB){
            Debug.Log("I've been hit!");
            health--;
            Destroy(obj.gameObject);
        }else if(obj.tag == "energyPoint"){
            AudioSource audio = obj.GetComponent<AudioSource>();
            obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            energy += 3;
            int time = 0;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }else if(obj.tag == "armorPoint"){
            AudioSource audio = obj.GetComponent<AudioSource>();
             obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            //energy += 3;
            timeActive = true;
            timer.done = false;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }else if(obj.tag == "healthPoint"){
            AudioSource audio = obj.GetComponent<AudioSource>();
             obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            health += 1;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }
    }
}
