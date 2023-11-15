using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegalonBossHandler : MonoBehaviour
{
    [SerializeField] Transform head;
    
    [SerializeField] Transform target;
    
    [SerializeField] GameObject bullet;
    
    [SerializeField] GameObject leftAttack;
    
    [SerializeField] GameObject rightAttack;
    
    Vector3 shootPos = new Vector3(0,0,0);
    
    Vector3 tarPos = new Vector3(0, 0, 0);

    [Range(0,75)]
    [SerializeField] int health;
    
    [SerializeField] MegalonAnimateStateChanger msc;
    
    [SerializeField] Text healthText;
    
    int rnd;
    
    public CentralGameScript sceneCheck;

    public AudioSource hurtAudio;
    
    public AudioSource attackAudio;
    
    [SerializeField] float time;
    
    public TotalPoints pointsInfo;
    
    bool bossDefeat = false;


    void Start(){
        time = 1.0f;
        leftAttack.SetActive(false);
        rightAttack.SetActive(false);
        healthText.text = "Megalon: " + health;
        SpawnBulletOverTime();
        PickAttackOverTime();
    }

    void Awake(){
        health =  75;

    }

    void Update(){
        shootPos = new Vector3(head.position.x, head.position.y, 0);
        tarPos = new Vector3(target.position.x, target.position.y, 0);
        if(health <= 30){
            time = 0.5f;
        }
        if(health <= 0){
            //Destroy(gameObject);
            if(!bossDefeat){
                pointsInfo.points += 2500;
                pointsHandler.singleton.addPoints(2500);
                bossDefeat = true;
            }
            sceneCheck.currentState = 999;
        }
        if(!bossDefeat){
            healthText.text = "Megalon: " + health;
        }else{
            healthText.text = "Megalon Defeated";
        }
    }

     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(time);
                Rigidbody2D newBullet = Instantiate(bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>();
                tarPos.z = 0;
                newBullet.velocity = (tarPos - transform.position);
                Destroy(newBullet.gameObject, 3);
            }

            yield return null;
            
         }
     }

     void PickAttackOverTime(){
        StartCoroutine(PickAttackOverTimeRoutine());
        IEnumerator PickAttackOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(5);
                    rnd = Random.Range(0,9);
                    if(rnd % 2 == 0){
                        msc.ChangeAnimationState("MegalonLeftAttack");
                        leftAttack.SetActive(true);
                        attackAudio.Play();
                        yield return new WaitForSeconds(2);
                        leftAttack.SetActive(false);
                        msc.ChangeAnimationState("MegalonIdle");
                    }else{
                        msc.ChangeAnimationState("MegalonRightAttack");
                        rightAttack.SetActive(true);
                        attackAudio.Play();
                        yield return new WaitForSeconds(2);
                        rightAttack.SetActive(false);
                        msc.ChangeAnimationState("MegalonIdle");
                    }
                }
                 yield return null;
            }
    }

     void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "FriendlyBullet"){
            health--;
            hurtAudio.Play();
            Destroy(obj.gameObject);
        }
     }
}
