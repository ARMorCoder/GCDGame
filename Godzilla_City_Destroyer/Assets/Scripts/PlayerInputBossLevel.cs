using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputBossLevel : MonoBehaviour
{
    [SerializeField] MovementBossLevel movement;
    public int health = 1;
    [SerializeField] int energy;
    [SerializeField] Transform body;
    [SerializeField] Text healthText;
    [SerializeField] Text energyText;
    ProjectileThrowerBossLevel pT;
    [SerializeField] bool timeActive = false;
    [SerializeField] TimeCountDown timer;
    [SerializeField] bool IB = false;//invincibility 
    public TotalPoints pointsInfo;
    [SerializeField] int time;

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
        if(!PauseMenu.gamePause){
            if(Input.GetKeyDown(KeyCode.F)){
                if(energy <= 0){
                    Debug.Log("out of energy!!");
                }else{ 
                    pT.Throw();
                    energy -= 1;
                }
            }
            if(timeActive){
                Debug.Log("Time is active!");
                if(timer.secondsLeft == 0 && !timer.done){
                    timer.setSeconds(time);
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
        if(obj.tag == "EnemyBullet" && !IB){
            Debug.Log("I've been hit!");
           GetComponent<AudioSource>().Play();
            health--;
            Destroy(obj.gameObject);
        }else if(obj.tag == "EnemyMelee" && !IB){
            GetComponent<AudioSource>().Play();
            Debug.Log("I've been hit!");
            health--;
        }else if(obj.tag == "energyPoint"){
            pointsHandler.singleton.addPoints(5);
            pointsInfo.points += 5;       
            AudioSource audio = obj.GetComponent<AudioSource>();
            obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            energy += obj.GetComponent<energyPowerScript>().amount;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }else if(obj.tag == "armorPoint"){
            pointsHandler.singleton.addPoints(10);
            pointsInfo.points += 10;
            AudioSource audio = obj.GetComponent<AudioSource>();
             obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            time = obj.GetComponent<energyPowerScript>().amount;
            timeActive = true;
            timer.done = false;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }else if(obj.tag == "healthPoint"){
            pointsHandler.singleton.addPoints(5);
            pointsInfo.points += 5;
            AudioSource audio = obj.GetComponent<AudioSource>();
             obj.GetComponent<Collider2D>().enabled = false;
            audio.Play();
            health += obj.GetComponent<energyPowerScript>().amount;
            obj.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject, audio.clip.length);

        }
    }
}
